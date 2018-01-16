using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    public class EspressoStrategy : IDrinkStrategy
    {
        public const String Name = "Espresso";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            return new Espresso();
        }
    }
}
