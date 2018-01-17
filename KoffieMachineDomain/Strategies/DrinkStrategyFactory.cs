using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Strategies.BasicRecipes;

namespace KoffieMachineDomain.Strategies
{
    public class DrinkStrategyFactory
    {
        private IDictionary<string, IDrinkStrategy> _strategyDictionairy;

        public IEnumerable<string> DrinkNames
        {
            get { return _strategyDictionairy.Keys; }
        }

        public DrinkStrategyFactory()
        {
            _strategyDictionairy = new Dictionary<string, IDrinkStrategy>();
            _strategyDictionairy[CoffeeStrategy.Name] = new CoffeeStrategy();
            _strategyDictionairy[CoffeeWithMilkStrategy.Name] = new CoffeeWithMilkStrategy();
            _strategyDictionairy[CoffeeWithSugarStrategy.Name] = new CoffeeWithSugarStrategy();
            _strategyDictionairy[CoffeeWithMilkAndSugarStrategy.Name] = new CoffeeWithMilkAndSugarStrategy();
            _strategyDictionairy[EspressoStrategy.Name] = new EspressoStrategy();
            _strategyDictionairy[EspressoWithMilkStrategy.Name] = new EspressoWithMilkStrategy();
            _strategyDictionairy[EspressoWithSugarStrategy.Name] = new EspressoWithSugarStrategy();
            _strategyDictionairy[EspressoWithMilkAndSugarStrategy.Name] = new EspressoWithMilkAndSugarStrategy();
            _strategyDictionairy[CapuccinoStrategy.Name] = new CapuccinoStrategy();
            _strategyDictionairy[CapuccinoWithSugarStrategy.Name] = new CapuccinoWithSugarStrategy();
            _strategyDictionairy[WienerMelangeStrategy.Name] = new WienerMelangeStrategy();
            _strategyDictionairy[CafeAuLaitStrategy.Name] = new CafeAuLaitStrategy();
            _strategyDictionairy[TeaStrategy.Name] = new TeaStrategy();
            _strategyDictionairy[HotChocolateStrategy.Name] = new HotChocolateStrategy();
            _strategyDictionairy[HotChocolateDeluxeStrategy.Name] = new HotChocolateDeluxeStrategy();
        }

        public IDrinkStrategy GetStrategy(string drinkName)
        {
            if (DrinkNames.Contains(drinkName))
            {
                return _strategyDictionairy[drinkName];
            }
            return null;
        }
    }
}
