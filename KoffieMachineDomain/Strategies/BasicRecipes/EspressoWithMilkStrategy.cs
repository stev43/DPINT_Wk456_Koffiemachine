﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;

namespace KoffieMachineDomain.Strategies.BasicRecipes
{
    class EspressoWithMilkStrategy:IDrinkStrategy
    {
        public const String Name = "EspressoWithMilk";

        public Drink CreateDrink(Strength strength, Amount sugarAmount, Amount milkAmount, string blend)
        {
            Drink drink = new Espresso();
            return new MilkDrink(milkAmount, drink);
        }
    }
}
