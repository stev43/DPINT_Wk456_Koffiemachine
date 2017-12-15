using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class DrinkFactory
    {
        private IDictionary<string, Type> _drinkList { get; set; }

        public IEnumerable<string> DrinkNames
        {
            get { return _drinkList.Keys; }
        }

        public DrinkFactory()
        {
            _drinkList = new Dictionary<string, Type>();
        }

        public Coffee GetDrink(string drinkName)
        {
            if (DrinkNames.Contains(drinkName))
            {
                Type type = _drinkList[drinkName];
                return (Coffee)Activator.CreateInstance(type);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddDrinkToList(string drinkName, Type type)
        {
            if (!DrinkNames.Contains(drinkName) && type.IsSubclassOf(typeof(Drink)))
            {
                _drinkList[drinkName] = type;
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }


}
