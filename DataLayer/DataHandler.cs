using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataHandler
    {
        private static DataHandler instance = null;

        public static DataHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataHandler();
                }
                return instance;
            }
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["TSQL"].ConnectionString;

        public DataTable GetTableData(string tableName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM " + tableName;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
