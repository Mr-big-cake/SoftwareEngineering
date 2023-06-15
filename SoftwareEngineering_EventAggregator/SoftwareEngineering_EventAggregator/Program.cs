using System;
using SoftwareEngineering_EventAggregator.Implementations;
using SoftwareEngineering_EventAggregator.Interfaces;
using System.Data.SqlClient;
using System.Data.Sql;
namespace SoftwareEngineering_EventAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscriber subscriber1 = new Subscriber(IObserver.TypeOfChange.Insert | IObserver.TypeOfChange.Delete | IObserver.TypeOfChange.Update);
            Subscriber subscriber2 = new Subscriber(IObserver.TypeOfChange.Insert);
            Subscriber subscriber3 = new Subscriber(IObserver.TypeOfChange.Delete);
            Subscriber subscriber4 = new Subscriber(IObserver.TypeOfChange.Update);
            Mediator mediator = new Mediator();
            mediator.AddSubscriber(subscriber1);
            mediator.AddSubscriber(subscriber2);
            mediator.AddSubscriber(subscriber3);
            mediator.AddSubscriber(subscriber4);

            Publisher publisher = new Publisher(mediator);
            publisher.DBConnection();

            Console.WriteLine(mediator);

        }
    }
}
