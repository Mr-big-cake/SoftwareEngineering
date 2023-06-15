using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineering_EventAggregator.Interfaces
{
    interface IPublisher: IObserver
    {
        protected const string connectionString = @"server=DESKTOP-QGUHKNA;Trusted_Connection=True;DataBase=DBEventAgregator;";
        public void DBConnection();
    }
}
