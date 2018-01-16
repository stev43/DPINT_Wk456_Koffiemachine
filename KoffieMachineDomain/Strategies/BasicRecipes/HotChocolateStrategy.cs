using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Adapter;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    public class HotChocolateStrategy : IDrinkStrategy
    {
        public const string Name = "Chocolate";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            return new HotChocolateAdapter();
        }
    }
}
