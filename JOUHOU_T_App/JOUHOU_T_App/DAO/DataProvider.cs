using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOUHOU_T_App.DAO
{
    public class DataProvider
    {
        private string connectString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\Admin\OneDrive\Documents\GitHub\JOUHOU_T_Demo\db_demo.mdb";

        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();

            try
            {
                using (OleDbConnection oleConnection = new OleDbConnection(connectString))
                {
                    oleConnection.Open();

                    OleDbCommand command = new OleDbCommand(query, oleConnection);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    adapter.Fill(data);

                    oleConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //Todo
            }
            return data;
        }


        public int ExcuteNonQuery(string query)
        {
            int data = 0;

            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(query, connection);
                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }

        public int ExcuteNonQueryForGroup(string query)
        {
            int data = 0;
            string query2 = "Select @@Identity";
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                command.CommandText = query2;
                data = (int)command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
