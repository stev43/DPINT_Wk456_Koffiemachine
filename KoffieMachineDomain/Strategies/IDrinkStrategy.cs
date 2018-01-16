using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Strategies
{
    public interface IDrinkStrategy
    {
        Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount);
    }
}
