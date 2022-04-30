using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class ConcreteSunroof : IDetail
    {
        private string _name = $"{Guid.NewGuid()}";
        public override string ToString() => "Люк: " + _name;
        public int Size { get; private set; }

        public ConcreteSunroof(IAbstractCarPart abstractCarPart)
        {
            DeepCopy(abstractCarPart);
        }

        public void DeepCopy(IAbstractCarPart abstractCarPart)
        {
            Size = abstractCarPart.Size;
        }

    }
}
