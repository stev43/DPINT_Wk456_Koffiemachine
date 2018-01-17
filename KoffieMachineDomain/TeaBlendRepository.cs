using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain
{
    public class TeaBlendRepository
    {
        private TeaAndChocoLibrary.TeaBlendRepository repository;

        public TeaBlendRepository()
        {
            repository = new TeaAndChocoLibrary.TeaBlendRepository();
        }

        public IEnumerable<string> GetNames()
        {
            return repository.BlendNames;
        }

        public TeaBlend GetTeaBlend(string blendName)
        {
            return repository.GetTeaBlend(blendName);
        }


    }
}
