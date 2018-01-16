using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    class CapuccinoWithSugarStrategy : IDrinkStrategy
    {
        public const string Name = "Capuccino with Sugar";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            Drink drink = new Capuccino(strength);
            return new SugarDrink(sugarAmount, drink);
        }
    }
}
