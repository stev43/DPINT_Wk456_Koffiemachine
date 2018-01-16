using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    class CoffeeWithMilkAndSugarStrategy : IDrinkStrategy
    {
        public const string Name = "CoffeeWithMilkAndSugar";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            Drink drink = new Coffee(strength);

            Drink milkdrink = new MilkDrink(sugarAmount, drink);
            Drink sugarDrink = new SugarDrink(sugarAmount, milkdrink);

            return sugarDrink;
        }
    }
}
