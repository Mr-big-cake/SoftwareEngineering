using System;
using System.Collections.Generic;
using System.Text;
using SoftwareEngineering_EventAggregator.Interfaces;

namespace SoftwareEngineering_EventAggregator.Implementations
{
    class Mediator : IMediator
    {
        public List<Subscriber> Subscribers { get; private set; } = new List<Subscriber>();

        public void AddSubscriber(Subscriber subscriber)
        {
            Subscribers.Add(subscriber);
        }
        public void DeleteSubscriber(Subscriber subscriber)
        {
            Subscribers.Remove(subscriber);
        }
        public void DistributionToSubs(IObserver.TypeOfChange typeOfChange, string @string = null)
        {
            foreach (var sub in Subscribers)
            {
                if (((((int)typeOfChange) & 1) == 1) &&
                    ((((int)typeOfChange) & 1) == (((int)sub.Subscription) & 1)))
                {
                    sub.AddLog("INSERT");
                }

                if ((((((int)typeOfChange) >> 1) & 1) == 1) &&
                    (((((int)typeOfChange) >> 1) & 1) == ((((int)sub.Subscription) >> 1) & 1)))
                {
                    sub.AddLog("DELETE");
                }

                if ((((((int)typeOfChange) >> 2) & 1) == 1) &&
                    (((((int)typeOfChange) >> 2) & 1) == ((((int)sub.Subscription) >> 2) & 1)))
                {
                    sub.AddLog("UPDATE");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var sub in Subscribers)
            {
                result.Append(sub);
            }
            return result.ToString();
        }
    }
}
