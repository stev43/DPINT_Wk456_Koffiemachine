using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class CoffeeFactory
    {
        private IDictionary<string, Type> _coffeeList { get; set; }

        public IEnumerable<string> CofeeNames
        {
            get { return _coffeeList.Keys; }
        }

        public CoffeeFactory()
        {
            _coffeeList = new Dictionary<string, Type>();
        }

        public Coffee GetCoffee(string coffeeName)
        {
            if (CofeeNames.Contains(coffeeName))
            {
                Type type = _coffeeList[coffeeName];
                return (Coffee)Activator.CreateInstance(type);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddCoffeeToList(string coffeeName, Type type)
        {
            if (!CofeeNames.Contains(coffeeName) && (type.IsSubclassOf(typeof(Coffee)) || type == typeof(Coffee)))
            {
                _coffeeList[coffeeName] = type;
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }


}
