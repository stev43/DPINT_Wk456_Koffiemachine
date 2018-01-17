using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class HotChocoloate : Drink
    {
        protected bool _isDeluxe { get; set; }
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

        public HotChocoloate(bool isDeluxe = false, Amount amount = Amount.Normal)
        {
            Amount = amount;
            _isDeluxe = isDeluxe;
            Name = "HotChocolate";
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Filling with hot chocolate.");
            if (_isDeluxe)
            {
                log.Add($"Adding special ingredients.");
            }
        }
    }
}
