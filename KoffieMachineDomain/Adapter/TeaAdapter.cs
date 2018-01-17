using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorator;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapter
{
    public class TeaAdapter : Tea
    {
        private TeaAndChocoLibrary.Tea _tea;
        public TeaAdapter(TeaBlend blend)
        {
            _tea = new TeaAndChocoLibrary.Tea();
            TeaBlend = blend;
        }

        public TeaBlend TeaBlend
        {
            get { return _tea.Blend; }
            set { _tea.Blend = value; }
        }

        public Amount Amount
        {
            get { return Amount.Normal; }
        }
        public override string Name
        {
            get { return _tea.Blend.Name; }
        }

        public override double GetPrice()
        {
            return Tea.BaseDrinkPrice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Dispensing Blend {Name}.");
            log.Add($"Setting tea amount to {Amount}.");
            log.Add("Filling with HotWater...");

        }
    }
}
