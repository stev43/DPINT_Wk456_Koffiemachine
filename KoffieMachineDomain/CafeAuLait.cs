using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class CafeAuLait : Coffee
    {

        public CafeAuLait(Strength strength = Strength.Normal, Amount amount = Amount.Normal, string name = "Café au Lait") : base(strength, amount, name)
        {

        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.5;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
            log.Add($"Finished making {Name}");
        }
    }
}
