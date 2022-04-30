using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class Car
    {
        private readonly string _name = $"{Guid.NewGuid()}";
        public override string ToString() => _name;
        private bool _isSwapDoor = false;
        public bool IsSwapDoor { get => _isSwapDoor; set => _isSwapDoor = value; }
        private bool _isSwapWindshield = false;
        public bool IsSwapWindshield { get => _isSwapWindshield; set => _isSwapWindshield = value; }
        private bool _isSwapFuelTankCap = false;
        public bool IsSwapFuelTankCap { get => _isSwapFuelTankCap; set => _isSwapFuelTankCap = value; }
        private bool _isSwapSunroof = false;
        public bool IsSwapSunroof { get => _isSwapSunroof; set => _isSwapSunroof = value; }
        
        public Car(int number)
        {
            for (int i = 0; i != 4 && number != 0; number >>= 1, i++)
            {
                switch (i)
                {
                    case 0:
                        if ((number & 1) == 1) _isSwapDoor = true;
                        break;
                    case 1:
                        if ((number & 1) == 1) _isSwapWindshield = true;
                        break ;
                    case 2:
                        if ((number & 1) == 1) _isSwapFuelTankCap = true;
                        break;
                    case 3:
                        if ((number & 1) == 1) _isSwapSunroof = true;
                        break;
                }
                
            }

        }

    }

}
