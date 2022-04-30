using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class Facade
    {
        List<Car> _listClientsRequests = new List<Car> { new Car(1), new Car(15), new Car(2)}; //(0, 16)

        List<IDetail> _listDetails = new List<IDetail> { new ConcreteDoor(Door.GetInstance()), new ConcreteFuelTankCap(FuelTankCap.GetInstance()), new ConcreteFuelTankCap(FuelTankCap.GetInstance())};


        Manager _manager = new Manager();
        ServiceCentre _serviceCentre;
        public Facade()
        {
            _serviceCentre = new ServiceCentre(_listClientsRequests);
            Manager manager2 = new Manager();

            _manager.SetNext(manager2);
            _manager.GetFirstHandler();
            _manager.SetListDetails(_listDetails);
            _serviceCentre.Manager = _manager;
        }

        public void StartWork()
        {
            Console.WriteLine("Работа сервисного центра запущена");
            Parallel.ForEach(_listClientsRequests, _serviceCentre.RepaireCar);
            _listClientsRequests.Clear();
            Thread.Sleep(1);
            Console.WriteLine();
        }

        public void GetClientRequests()
        {
            Console.WriteLine("Список клиентских запросов: ");
            if (_listClientsRequests.Count == 0) Console.Write("\tCписок пуст");
            foreach (var i in _listClientsRequests)
            {
                Console.WriteLine("\t" + i);
            }
            Console.WriteLine();
        }
        public void AddClientRequests()
        {
            Random random = new Random();
            _listClientsRequests.Add(new Car(random.Next(0, 16)));
            Console.WriteLine("Добавление нового запроса");
        }

        public void GetDetailsList()
        {
            Console.WriteLine("Список деталей в пуле: ");
            if (_listDetails.Count == 0) Console.Write("\tCписок пуст");
            foreach (var i in _listDetails)
            {
                Console.WriteLine("\t" + i);
            }
            Console.WriteLine();
        }
        public void GetWorkshopState() { Console.WriteLine("Состояние мастерской: " +  (Workshop._isBusy?"Занята":"Свободна")); }
        public void GetInfoRecycling() 
        {
            Console.WriteLine("Список утилизированных деталей:");
            foreach (var i in Workshop._trush)
                Console.WriteLine("\t" + i);
            Console.WriteLine();
        }
    }
}
