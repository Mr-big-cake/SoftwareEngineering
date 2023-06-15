using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineering_EventAggregator.Interfaces
{
    interface ISubscriber: IObserver
    {
        public void AddLog(string @string);
    }
}
