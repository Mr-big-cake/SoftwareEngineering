using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineering_EventAggregator.Interfaces
{
    interface IObserver
    {
        [Flags] enum TypeOfChange
        {
            Insert = 1,
            Delete = 2,
            Update = 4
        }
    }
}
