using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    class EspressoWithSugarStrategy:IDrinkStrategy
    {
        public const String Name = "EspressoWithSugar";

        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            Drink drink = new Capuccino();
            return new SugarDrink(sugarAmount, drink);
        }
    }
}
