using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapter
{
    public class HotChocolateAdapter : HotChocoloate
    {
        private TeaAndChocoLibrary.HotChocolate _hotChocolate;

        HotChocolateAdapter(TeaAndChocoLibrary.HotChocolate hotChocolate, bool isDeluxe = false)
        {
            _hotChocolate = hotChocolate;
            if (isDeluxe)
            {
                _hotChocolate.MakeDeluxe();
            }
            _isDeluxe = isDeluxe;
        }

        public HotChocolateAdapter(bool isDeluxe = false)
        {
            _hotChocolate = new HotChocolate();
            if (isDeluxe)
            {
                _hotChocolate.MakeDeluxe();
            }
            _isDeluxe = isDeluxe;
        }

        public Amount Amount
        {
            get { return Amount.Normal; }
        }

        public override string Name
        {
            get { return _hotChocolate.GetNameOfDrink(); }
        }

        public override double GetPrice()
        {
            return _hotChocolate.Cost();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            foreach (string buildStep in _hotChocolate.GetBuildSteps())
            {
                log.Add(buildStep);
            }
        }
    }
}
