using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SE_ServiceCentre
{
    internal class Workshop
    {
        public static bool _isBusy = false; 
        public static List<IDetail> _trush = new List<IDetail>();
        public static int lastRandomState = 0;
        public static void RepairDetail(IDetail detail, List<IDetail> details)
        {
            _isBusy = true;
            Thread.Sleep(500);
            Random random = new Random();
            if ((lastRandomState = random.Next(0, 100) % 2) == 0)
            {
                details.Add(detail);
                Console.WriteLine($"WS --->Деталь {detail} возвращена в пул");
            }
            else
            {
                Console.WriteLine($"WS --->Деталь {detail} утилизирована");
                _trush.Add(detail);
            }
            _isBusy = false;
        }
    }
}
