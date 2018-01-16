using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    class CoffeeWithSugarStrategy : IDrinkStrategy
    {
        public const string Name = "CoffeeWithSugar";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            Drink drink = new Coffee(strength);

            return new SugarDrink(sugarAmount, drink);
        }
    }
}
