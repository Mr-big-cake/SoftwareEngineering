using System;
using System.Collections.Generic;
using System.Text;
using SoftwareEngineering_EventAggregator.Interfaces;
using System.Data.SqlClient;

namespace SoftwareEngineering_EventAggregator.Implementations
{
    class Publisher: IPublisher
    {
        private static SqlConnection connection = new SqlConnection();
        private static Mediator _mediator;
        public Publisher(Mediator mediator) 
        {
            _mediator = mediator;
        }

        public void DBConnection()
        {
            bool b = SqlDependency.Start(IPublisher.connectionString);
            AddEventChanges();
            Console.WriteLine("Ожидание сигнала об изменении от сервера ..." + b.ToString());
            Console.WriteLine("Для выхода нажмите <Enter>");
            Console.ReadLine();
            SqlDependency.Stop(IPublisher.connectionString);
            connection.Close();
        }
        public static void AddEventChanges()
        {
            connection = new SqlConnection(IPublisher.connectionString);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT Data1 FROM dbo.Table1;", connection))
            {
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(WaitChange);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine($"\r\n {reader.GetInt32(0)}");
                        }
                    }
                }
            }
            connection.Close();
        }

        public static void WaitChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info.ToString() == "Invalid") return;
            Console.WriteLine("Произошло изменение в БД:");
            Console.WriteLine("\tТип изменения - " + e.Info.ToString());
            IObserver.TypeOfChange typeOfChange = 0;
            if (e.Info.ToString() == "Insert") typeOfChange |= IObserver.TypeOfChange.Insert;
            if (e.Info.ToString() == "Delete") typeOfChange |= IObserver.TypeOfChange.Delete;
            if (e.Info.ToString() == "Update") typeOfChange |= IObserver.TypeOfChange.Update;
            _mediator.DistributionToSubs(typeOfChange);
            Console.WriteLine("Ожидание сигнала об изменении от сервера ...");
            Console.WriteLine("Для выхода нажмите <Enter>");
            AddEventChanges();
        }
    }
}
