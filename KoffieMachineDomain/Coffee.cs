using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Coffee : Drink
    {
        public virtual Strength DrinkStrength { get; set; }
        private string _name;
        public Coffee(Strength strength = Strength.Normal, string name = "Koffie")
        {
            _name = name;
            DrinkStrength = strength;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice;
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
