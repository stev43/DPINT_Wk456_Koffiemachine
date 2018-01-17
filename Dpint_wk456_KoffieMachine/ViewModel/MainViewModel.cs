using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using KoffieMachineDomain.Adapter;
using KoffieMachineDomain.Decorator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using KoffieMachineDomain.Strategies;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private TeaBlendRepository _blendRepository;
        private DrinkStrategyFactory _strategyFactory;
        private Dictionary<string, double> _cashOnCards;
        public ObservableCollection<string> LogText { get; private set; }

        public MainViewModel()
        {
            _strategyFactory = new DrinkStrategyFactory();
            _blendRepository = new TeaBlendRepository();


            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;

            LogText = new ObservableCollection<string>();
            LogText.Add("Starting up...");
            LogText.Add("Done, what would you like to drink?");

            _cashOnCards = new Dictionary<string, double>();
            _cashOnCards["Arjen"] = 5.0;
            _cashOnCards["Bert"] = 3.5;
            _cashOnCards["Chris"] = 7.0;
            _cashOnCards["Daan"] = 6.0;
            PaymentCardUsernames = new ObservableCollection<string>(_cashOnCards.Keys);
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
        }

        #region tea properties

        public ObservableCollection<string> TeaBlendNames
        {
            get { return new ObservableCollection<string>(_blendRepository.GetNames()); }
        }

        private string _selectedBlend;

        public string SelectedBlend
        {
            get { return _selectedBlend; }
            set
            {
                _selectedBlend = value;
                RaisePropertyChanged(() => SelectedBlend);
            }
        }

        #endregion

        #region Drink properties to bind to

        private Drink _selectedDrink;

        public string SelectedDrinkName
        {
            get { return _selectedDrink?.Name; }
        }

        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }

        #endregion Drink properties to bind to

        #region Payment

        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            PayDrinkByCard();
            if (RemainingPriceToPay == 0 && _selectedDrink != null)
            {
                PrepareDrink();
            }
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            PayDrinkByCoin(coinValue);
            if (RemainingPriceToPay == 0 && _selectedDrink != null)
            {
                PrepareDrink();
            }
        });

        public void PayDrinkByCard()
        {
            double insertedMoney;
            if (_selectedDrink != null)
            {
                insertedMoney = _cashOnCards[SelectedPaymentCardUsername];
                if (RemainingPriceToPay <= insertedMoney)
                {
                    _cashOnCards[SelectedPaymentCardUsername] = insertedMoney - RemainingPriceToPay;
                    RemainingPriceToPay = 0;
                }
                else // Pay what you can, fill up with coins later.
                {
                    _cashOnCards[SelectedPaymentCardUsername] = 0;

                    RemainingPriceToPay -= insertedMoney;
                }
                LogText.Add(
                    $"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        public void PayDrinkByCoin(double insertedMoney)
        {
            if (_selectedDrink != null)
            {
                RemainingPriceToPay = Math.Max(Math.Round(RemainingPriceToPay - insertedMoney, 2), 0);
                LogText.Add(
                    $"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");
            }
        }

        public double PaymentCardRemainingAmount => _cashOnCards.ContainsKey(SelectedPaymentCardUsername ?? "")
            ? _cashOnCards[SelectedPaymentCardUsername]
            : 0;

        public ObservableCollection<string> PaymentCardUsernames { get; set; }

        private string _selectedPaymentCardUsername;

        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        private double _remainingPriceToPay;

        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set
            {
                _remainingPriceToPay = value;
                RaisePropertyChanged(() => RemainingPriceToPay);
            }
        }

        #endregion Payment   

        #region Coffee buttons

        private Strength _coffeeStrength;

        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set
            {
                _coffeeStrength = value;
                RaisePropertyChanged(() => CoffeeStrength);
            }
        }

        private Amount _sugarAmount;

        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set
            {
                _sugarAmount = value;
                RaisePropertyChanged(() => SugarAmount);
            }
        }

        private Amount _milkAmount;

        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set
            {
                _milkAmount = value;
                RaisePropertyChanged(() => MilkAmount);
            }
        }

        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            if (_strategyFactory.DrinkNames.Contains(drinkName))
            {
                _selectedDrink = _strategyFactory.GetStrategy(drinkName)
                    .CreateDrink(_coffeeStrength, _sugarAmount, _milkAmount, _selectedBlend);
            }
            else
            {
                LogText.Add($"Could not make {drinkName}, recipe not found.");
            }

            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add(
                    $"Selected {_selectedDrink.Name}, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        });

        private void PrepareDrink()
        {
            if (RemainingPriceToPay == 0)
            {
                _selectedDrink.LogDrinkMaking(LogText);
                LogText.Add($"Finished making {_selectedDrink.Name}");
                LogText.Add("------------------");
                _selectedDrink = null;
            }
        }
        #endregion Coffee buttons        
    }
}