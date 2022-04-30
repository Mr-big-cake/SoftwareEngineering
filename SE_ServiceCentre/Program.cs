using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();


            facade.StartWork();
            facade.GetWorkshopState();
            facade.GetDetailsList();
            //facade.GetClientRequests();
            //facade.AddClientRequests();
            //facade.GetClientRequests();
            //facade.StartWork();
            facade.GetInfoRecycling();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadLine();
        }

    }

}
