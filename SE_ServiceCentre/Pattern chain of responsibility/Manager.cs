using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class Manager : AbstractHandler
    {
        private static readonly object _lock = new object();
        public Manager() { }
        private readonly string _name = $"Менеджер №{Guid.NewGuid()}";
        public override string ToString() => _name;
        public override object Handle(object request)
        {
            var _listDetails = FirstHandler.Details;
            if (!IsBusy)
            {
                IsBusy = true;
                Console.WriteLine($"{_name} выполняет ремонт {request as Car}.");
                Thread.Sleep(3000); // Ремонт
                //2. Обращение в пул деталей и замена деталей, которые смогли в нем найти
                var needDetailes = new List<IDetail>();
                lock (_lock)
                {
                    if ((request as Car).IsSwapDoor)
                    {
                        var detail = new ConcreteDoor(Door.GetInstance());
                        Thread thread = new Thread(() => Workshop.RepairDetail(detail, _listDetails));
                        thread.Start();
                        //thread.Join();
                        bool flag = false;
                        foreach (var d in _listDetails)
                        {
                            if (d is ConcreteDoor)
                            {
                                flag = true;
                                _listDetails.Remove(d);
                                break;
                            }

                        }

                        if (!flag)
                            needDetailes.Add(new ConcreteDoor(Door.GetInstance()));

                        (request as Car).IsSwapDoor = false;
                    }
                    if ((request as Car).IsSwapFuelTankCap)
                    {
                        var detail = new ConcreteFuelTankCap(FuelTankCap.GetInstance());
                        Thread thread = new Thread(() => Workshop.RepairDetail(detail, _listDetails));
                        thread.Start();
                        //thread.Join();
                        bool flag = false;
                        foreach (var d in _listDetails)
                        {
                            if (d is ConcreteFuelTankCap)
                            {
                                flag = true;
                                _listDetails.Remove(d);
                                break;
                            }

                        }

                        if (!flag)
                            needDetailes.Add(new ConcreteFuelTankCap(FuelTankCap.GetInstance()));

                        (request as Car).IsSwapFuelTankCap = false;
                    }
                    if ((request as Car).IsSwapSunroof)
                    {
                        var detail = new ConcreteSunroof(Sunroof.GetInstance());
                        Thread thread = new Thread(() => Workshop.RepairDetail(detail, _listDetails));
                        thread.Start();
                        //thread.Join();
                        bool flag = false;
                        foreach (var d in _listDetails)
                        {
                            if (d is ConcreteSunroof)
                            {
                                flag = true;
                                _listDetails.Remove(d);
                                break;
                            }

                        }

                        if (!flag)
                            needDetailes.Add(new ConcreteSunroof(Sunroof.GetInstance()));

                        (request as Car).IsSwapSunroof = false;
                    }
                    if ((request as Car).IsSwapWindshield)
                    {
                        var detail = new ConcreteWindshield(Windshield.GetInstance());
                        Thread thread = new Thread(() => Workshop.RepairDetail(detail, _listDetails));
                        thread.Start();
                        //thread.Join();
                        bool flag = false;
                        foreach (var d in _listDetails)
                        {
                            if (d is ConcreteWindshield)
                            {
                                flag = true;
                                _listDetails.Remove(d);
                                break;
                            }

                        }

                        if (!flag)
                            needDetailes.Add(new ConcreteWindshield(Windshield.GetInstance()));

                        (request as Car).IsSwapWindshield = false;
                    }
                    //3. Дождаться производства деталей, отсутствующих в пуле (на заводе)
                    for (int i = 0; i < needDetailes.Count; i++) Thread.Sleep(500);

                    IsBusy = false;
                    Console.WriteLine($"{_name}: ремонт {request as Car}. завершен!");
                }
                
                return null;
            }
            else
            {
                return base.Handle(request);
            }

        }

        public void SetListDetails(List<IDetail> details) => Details = details;
    }

}
