using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal interface IAbstractCarPartsFactory
    {
        IAbstractBaseCarPart CreateBaseCarPart();
        IAbstractAuxiliaryCarPart CreateAuxiliaryCarPart();
    }

}
