using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Capuccino : Coffee
    {
        public Capuccino(Strength strength = Strength.Normal, Amount amount = Amount.Normal, string name = "Capuccino") : base(strength, amount, name)
        {


        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.8;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");

            log.Add($"Finished making {Name}");
        }
    }
}
