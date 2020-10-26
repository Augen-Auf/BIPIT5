using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public static string connectionString = @"Data Source=DESKTOP-M0UINHO\SQLSERVER;Initial Catalog=adverst;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection(connectionString);
        public List<string[]> GetData()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT IdO, Client, Service, Time, FORMAT(Price, 'C0') as Price, " +
                "FORMAT(Total, 'C0') as Total, FORMAT (Date, 'dd.MM.yyyy') as Date FROM [OrderView]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
            }
            reader.Close();
            sqlConnection.Close();
            return data;
        }
        public Dictionary<int, string> Clients()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT IdC, Client FROM [Client]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            while (reader.Read())
            {
                dict.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
            }
            sqlConnection.Close();
            return dict;
        }
        public Dictionary<int, string> Services()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT IdS, Service FROM [Service]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            while (reader.Read())
            {
                dict.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
            }
            sqlConnection.Close();
            return dict;
        }
        public void NewRec(int IdC, int IdS, int Time, DateTime Date)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO[Order] (IdC_FK, IdS_FK, Time, Date) VALUES (@IdC_FK, @IdS_FK, @Time, @Date)", sqlConnection);
            command.Parameters.AddWithValue("IdC_FK", IdC);
            command.Parameters.AddWithValue("IdS_FK", IdS);
            command.Parameters.AddWithValue("Time", Time);
            command.Parameters.AddWithValue("Date", Date);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
