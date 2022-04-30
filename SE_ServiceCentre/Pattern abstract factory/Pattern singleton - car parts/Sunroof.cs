using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class Sunroof : IAbstractAuxiliaryCarPart
    {
        public int Size { get; set; } = 7;
        private Sunroof() { }
        private static Sunroof _instance;
        private static readonly object _lock = new object();
        public static Sunroof GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Sunroof();
                    }

                }

            }

            return _instance;
        }
        public override string ToString() => "Стекло люка";
    }

}
