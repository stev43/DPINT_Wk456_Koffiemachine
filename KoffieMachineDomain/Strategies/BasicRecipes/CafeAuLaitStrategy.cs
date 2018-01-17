using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    public class CafeAuLaitStrategy : IDrinkStrategy
    {
        public const string Name = "Café au Lait";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount, string blend)
        {
            return new CafeAuLait();
        }
    }
}
