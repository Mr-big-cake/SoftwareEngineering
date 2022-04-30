using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class Windshield : IAbstractBaseCarPart
    {
        public int Size { get; set; } = 8;
        private Windshield() { }
        private static Windshield _instance;
        private static readonly object _lock = new object();
        public static Windshield GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Windshield();
                    }

                }

            }

            return _instance;
        }
        public override string ToString() => "Лобовое стекло";

    }

}
