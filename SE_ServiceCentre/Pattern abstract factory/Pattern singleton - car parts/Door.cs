using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class Door : IAbstractBaseCarPart
    {
        public int Size { get; set; } = 5;
        private Door() { }
        private static Door _instance;
        private static readonly object _lock = new object();
        public static Door GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Door();
                    }
                }

            }

            return _instance;
        }
        public override string ToString() => "Дверь";

    }

}
