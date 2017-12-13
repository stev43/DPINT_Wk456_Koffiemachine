using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    class SugarDecorator : DrinkDecorator
    {
        public virtual Amount SugarAmount { get; private set; }

        public SugarDecorator(Amount amount)
        {
            SugarAmount = amount;
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
