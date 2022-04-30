using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class CarBodyFactory : IAbstractCarPartsFactory
    {
        public IAbstractBaseCarPart CreateBaseCarPart()
        {
            return Door.GetInstance();
        }

        public IAbstractAuxiliaryCarPart CreateAuxiliaryCarPart()
        {
            return FuelTankCap.GetInstance();
        }

    }

}
