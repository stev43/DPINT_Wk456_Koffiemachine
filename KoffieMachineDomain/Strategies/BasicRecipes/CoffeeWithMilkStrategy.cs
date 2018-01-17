using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    public class CoffeeWithMilkStrategy : IDrinkStrategy
    {
        public const string Name = "CoffeeWithMilk";

        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount, string blend)
        {
            Drink drink = new Coffee(strength);

            return new MilkDrink(milkAmount, drink);
        }
    }
}
