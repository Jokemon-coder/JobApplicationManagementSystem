using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace haetutTyot
{
    class CONNECT
    {
        public string sentence()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString; //Connection string is taken from the configuration file. 
            return connectionString;
        }

        private MySqlConnection connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString);

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenAndCloseConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }

        }
    }
}
