using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Espresso : Coffee
    {
        public Espresso() : base(Strength.Strong, Amount.Few, "Espresso")
        {
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.7;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add("Adding milk to coffee...");
            log.Add($"Finished making {Name}");
        }
    }
}
