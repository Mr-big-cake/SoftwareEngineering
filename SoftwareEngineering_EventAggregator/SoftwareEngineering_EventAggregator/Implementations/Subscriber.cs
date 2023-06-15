using System;
using System.Collections.Generic;
using System.Text;
using SoftwareEngineering_EventAggregator.Interfaces;

namespace SoftwareEngineering_EventAggregator.Implementations
{
    class Subscriber : ISubscriber
    {
        public IObserver.TypeOfChange Subscription { set; get; } = 0;
        private List<String> log = new List<string>();
        private int counterLog = 0;
        private static int counterSubs = 0;
        private int numberSub;
        public Subscriber(IObserver.TypeOfChange typeOfChange)
        {
            
            numberSub = counterSubs++;
            Subscription = typeOfChange;
        }

        public void AddLog(string @string)
        {
            log.Add(counterLog++ + ": " + @string + "\n");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Subscriber №");
            result.Append(numberSub);
            result.Append(Environment.NewLine);
            foreach (string str in log)
            {
                result.Append("\t");
                result.Append(str);
            }
            return result.ToString();
        }
    }
}
