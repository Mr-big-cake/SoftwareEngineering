using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class CarGlassFactory : IAbstractCarPartsFactory
    {
        public IAbstractBaseCarPart CreateBaseCarPart()
        {
            return Windshield.GetInstance();
        }

        public IAbstractAuxiliaryCarPart CreateAuxiliaryCarPart()
        {
            return Sunroof.GetInstance();
        }

    }

}
