using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Coffee : Drink
    {
        public Strength DrinkStrength { get; set; }
        public Amount Amount { get; set; }

        private string _name;
        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Coffee(Strength strength = Strength.Normal, Amount amount = Amount.Normal)
        {
            DrinkStrength = strength;
            Amount = amount;
            Name = "Koffie";
        }

        protected Coffee(Strength strength = Strength.Normal, Amount amount = Amount.Normal, string name = "Koffie")
        {
            _name = name;
            DrinkStrength = strength;
            Amount = amount;
        }

        public override double GetPrice()
        {
            return 1;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add($"Setting coffee amount to {Amount}.");
            log.Add("Filling with coffee...");
        }
    }
}
