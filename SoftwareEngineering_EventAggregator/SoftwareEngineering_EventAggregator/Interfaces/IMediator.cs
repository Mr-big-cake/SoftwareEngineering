using System;
using System.Collections.Generic;
using System.Text;
using SoftwareEngineering_EventAggregator.Implementations;

namespace SoftwareEngineering_EventAggregator.Interfaces
{
    interface IMediator:IObserver
    {
        public void DistributionToSubs(IObserver.TypeOfChange typeOfChange, string @string = null);
        public void AddSubscriber(Subscriber subscriber);
    }
}
