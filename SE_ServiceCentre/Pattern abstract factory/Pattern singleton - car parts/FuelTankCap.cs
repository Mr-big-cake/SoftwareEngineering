using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class FuelTankCap : IAbstractAuxiliaryCarPart
    {
        public int Size { get; set; } = 6;
        private FuelTankCap() { }
        private static FuelTankCap _instance;
        private static readonly object _lock = new object();
        public static FuelTankCap GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FuelTankCap();
                    }

                }

            }

            return _instance;
        }
        public override string ToString() => "Крышка топливного бака";

    }

}
