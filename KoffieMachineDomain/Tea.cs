using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    class Tea : Drink
    {
        public Amount Amount { get; set; }

        private string _name;
        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice;
        }

        public Tea()
        {
            Amount = Amount.Normal;
            Name = "Thee";
        }
    }
}
