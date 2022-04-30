using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class ServiceCentre
    {
        private List<Car> _listClientsRequests;
        private Manager _manager;
        public Manager Manager { set => _manager = value; get => _manager; }
        public ServiceCentre(List<Car>  listClientsRequests) => _listClientsRequests = listClientsRequests;
        public void RepaireCar(Car car)
        {
            _manager.Handle(car);
            //_listClientsRequests.Remove(car);
        }

    }

}
