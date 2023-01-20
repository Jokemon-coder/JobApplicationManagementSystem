using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace haetutTyot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        class Connect
        {
            public string sentence()
            {
                return "datasource=localhost; port=3306; username=root; password=1234; database=haetutTyot;";
            }

            private MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234; database=haetutTyot;");

            public MySqlConnection getConnection()
            {
                return connection;
            }

            public void openAndCloseConnection()
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }else if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
                
            }
        }

        class TyoHakemus
        {
            Connect connection = new Connect();
        

            public bool addApplication(int ID, string employerName, string roleName, string workAddress, string contactInfo, string gotReply, string gotInterv, string gotWork)
            {
                MySqlCommand command = new MySqlCommand();
                String addingWhere = "INSERT INTO tyohakemukset " + "(ID, employerName, roleName, workAddress, contactInfo, appDate, gotReply, gotInterview, saatuTyo)" + "VALUES (@id, @en, @rn, @wa, @ci, @ad, @gr, @gi, @st);";
                command.CommandText = addingWhere;
                command.Connection = connection.getConnection();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = ID;
                command.Parameters.Add("@en", MySqlDbType.VarChar).Value = employerName;
                command.Parameters.Add("@rn", MySqlDbType.VarChar).Value = roleName;
                command.Parameters.Add("@wa", MySqlDbType.VarChar).Value = workAddress;
                command.Parameters.Add("@ad", MySqlDbType.VarChar).Value = contactInfo;
                command.Parameters.Add("@gr", MySqlDbType.VarChar).Value = gotReply;
                command.Parameters.Add("@gi", MySqlDbType.VarChar).Value = gotInterv;
                command.Parameters.Add("@st", MySqlDbType.VarChar).Value = gotWork;

                connection.openAndCloseConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    connection.openAndCloseConnection();
                    return true;
                }else
                {
                    connection.openAndCloseConnection();
                    return false;
                }

            }

            public DataTable getApplications()
            {
                MySqlCommand command = new MySqlCommand("SELECT ID, employerName, roleName, workAddress, contactInfo, appDate, gotReply, gotInterview, saatuTyo FROM haetutTyot", connection.getConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                return table;
            }
        }
    }
}
