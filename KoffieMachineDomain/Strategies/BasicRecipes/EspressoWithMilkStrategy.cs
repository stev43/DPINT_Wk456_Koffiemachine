using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    class EspressoWithMilkStrategy:IDrinkStrategy
    {
        public const String Name = "Espresso with milk";

        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            Drink drink = new Espresso();
            return new MilkDrink(milkAmount, drink);
        }
    }
}
