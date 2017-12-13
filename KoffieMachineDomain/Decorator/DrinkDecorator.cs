using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain;

namespace KoffieMachineDomain.Decorator
{
    public class DrinkDecorator : Drink
    {
        protected Drink component;

        public override string Name
        {
            get { return component.Name; }
            set { component.Name = value; }
        }
        public override double GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
