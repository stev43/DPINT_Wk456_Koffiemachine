﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain
{
    public class Tea : Drink
    {
        public TeaBlend Blend { get; set; }
        public Amount Amount { get; set; }

        private string _name;
        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice;
        }

        public Tea(Amount amount = Amount.Normal)
        {
            Amount = amount;
            Name = "Teas";
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Dispensing Blend {Blend.Name}.");
            log.Add($"Setting tea amount to {Amount}.");
            log.Add("Filling with HotWater...");

        }
    }
}
