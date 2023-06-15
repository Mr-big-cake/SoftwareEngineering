using System;
using System.Data.SqlClient;
using System.Data.Sql;

namespace DB_RequestSender
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"server=DESKTOP-QGUHKNA;Trusted_Connection=Yes;DataBase=DBEventAgregator;");
            try
            {
                conn.Open();
                using (SqlCommand sql = conn.CreateCommand())
                {
                    SqlCommand com = new SqlCommand(@"INSERT Table1 (Data1) VALUES (2011);", conn);
                    //SqlDataReader read = com.ExecuteReader();
                    com.ExecuteNonQuery();
                    //read.Read();

                    //Console.WriteLine(read["Data1"].ToString());
                }

                conn.Close();
            }
            catch (Exception ex)
            {

                conn.Close();
            }
        }
    }
}
