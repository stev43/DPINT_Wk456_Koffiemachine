using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    public class CoffeeStrategy : IDrinkStrategy
    {
        public const string Name = "Coffee";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount, string blend)
        {
            return new Coffee(strength, Amount.Normal);
        }
    }
}
