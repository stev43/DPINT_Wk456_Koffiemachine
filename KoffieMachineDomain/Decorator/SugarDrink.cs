using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public class SugarDrink : DrinkDecorator
    {
        public virtual Amount SugarAmount { get; private set; }

        public SugarDrink(Amount amount, Drink drink)
        {
            SugarAmount = amount;
            base.component = drink;
        }

        public override double GetPrice()
        {
            return component.GetPrice() + 0.1;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            component.LogDrinkMaking(log);

            log.Add($"Setting sugar amount to {SugarAmount}.");
            log.Add("Adding sugar...");
        }
    }
}
