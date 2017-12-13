using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    class MilkDecorator : DrinkDecorator
    {
        public virtual Amount MilkAmount { get; private set; }

        public MilkDecorator(Amount amount)
        {
            MilkAmount = amount;
        }

        public override double GetPrice()
        {
            return component.GetPrice() + 0.15;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            component.LogDrinkMaking(log);

            log.Add($"Setting milk amount to {MilkAmount}.");
            log.Add("Adding milk...");
        }
    }
}
