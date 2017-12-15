using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public class MilkDrink : DrinkDecorator
    {
        public virtual Amount MilkAmount { get; private set; }

        public MilkDrink(Amount amount, Drink drink)
        {
            MilkAmount = amount;
            base.component = drink;
        }

        public override double GetPrice()
        {
            return component.GetPrice() + 0.15;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            component.LogDrinkMaking(log);

            log.Add($"Setting milk amount to {MilkAmount}.");
            log.Add("Adding milk to coffee...");
        }
    }
}
