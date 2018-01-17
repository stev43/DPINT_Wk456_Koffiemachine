using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Adapter;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    public class TeaWithSugarStrategy : IDrinkStrategy
    {
        public const string Name = "TeaWithSugar";
        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount, string blend)
        {
            TeaBlendRepository repositpory = new TeaBlendRepository();
            TeaAdapter drink = new TeaAdapter(repositpory.GetTeaBlend(blend));
            return new SugarDrink(sugarAmount, drink);
        }
    }
}
