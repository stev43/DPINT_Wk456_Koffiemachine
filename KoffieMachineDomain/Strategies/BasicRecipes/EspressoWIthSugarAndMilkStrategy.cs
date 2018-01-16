using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    class EspressoWIthSugarAndMilkStrategy:IDrinkStrategy
    {
        public const String Name = "Espresso with sugar and milk";

        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            Drink drink = new Espresso();
            Drink sugarDrink = new SugarDrink(sugarAmount, drink);
            Drink milkDrink = new MilkDrink(milkAmount, sugarDrink);
            return milkDrink;
        }
    }
}
