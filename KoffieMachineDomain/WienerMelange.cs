using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class WienerMelange : Capuccino
    {

        public WienerMelange() : base(Strength.Weak, Amount.Normal, "Wiener Melange")
        {
            //    HasSugar = false;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice * 2;
        }
    }
}
