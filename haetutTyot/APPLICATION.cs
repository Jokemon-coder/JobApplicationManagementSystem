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
    class APPLICATION
    {
        CONNECT connection = new CONNECT();


        public bool AddApplication(int ID, String employerName, String roleName, String workAddress, String contactInfo, String postLink, DateTime? dateTime, String gotReply, String gotInterv, String gotWork)
        {
            //Create SQL command and it's string on what to add and where to database
            MySqlCommand command = new MySqlCommand();
            String addingWhere = "INSERT INTO tyohakemukset " + "(ID, employerName, roleName, workAddress, contactInfo, ilmLink, appDate, gotReply, gotInterview, saatuTyo)" + "VALUES (@id, @en, @rn, @wa, @ci, @li, @ad, @gr, @gi, @st);";
            command.CommandText = addingWhere;
            command.Connection = connection.GetConnection();
            command.Parameters.Add("@id", MySqlDbType.UInt32).Value = ID;
            command.Parameters.Add("@en", MySqlDbType.VarChar).Value = employerName;
            command.Parameters.Add("@rn", MySqlDbType.VarChar).Value = roleName;
            command.Parameters.Add("@wa", MySqlDbType.VarChar).Value = workAddress;
            command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = contactInfo;
            command.Parameters.Add("@li", MySqlDbType.VarChar).Value = postLink;
            command.Parameters.Add("@ad", MySqlDbType.DateTime).Value = dateTime;
            command.Parameters.Add("@gr", MySqlDbType.VarChar).Value = gotReply;
            command.Parameters.Add("@gi", MySqlDbType.VarChar).Value = gotInterv;
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = gotWork;

            connection.OpenAndCloseConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                connection.OpenAndCloseConnection();
                return true;
            }
            else
            {
            connection.OpenAndCloseConnection();
            return false;
            }

        }

        public bool EditApplication(int ID, String employerName, String roleName, String workAddress, String contactInfo, String postLink, DateTime? dateTime ,String gotReply, String gotInterv, String gotWork)
        {
            //Create SQL command and it's string on what to update based on ID in the database
            MySqlCommand command = new MySqlCommand();
            String updatingWhere = "UPDATE `tyohakemukset` SET `employerName` = @en, `roleName` = @rn, `workAddress` = @wa, `contactInfo` = @ci, `ilmLink` = @li ,`appDate` = @ad, `gotReply` = @gr, `gotInterview` = @gi, `saatuTyo` = @st WHERE ID = @id";
            command.CommandText = updatingWhere;
            command.Connection = connection.GetConnection();
            command.Parameters.Add("@id", MySqlDbType.UInt32).Value = ID;
            command.Parameters.Add("@en", MySqlDbType.VarChar).Value = employerName;
            command.Parameters.Add("@rn", MySqlDbType.VarChar).Value = roleName;
            command.Parameters.Add("@wa", MySqlDbType.VarChar).Value = workAddress;
            command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = contactInfo;
            command.Parameters.Add("@li", MySqlDbType.VarChar).Value = postLink;
            command.Parameters.Add("@ad", MySqlDbType.DateTime).Value = dateTime;
            command.Parameters.Add("@gr", MySqlDbType.VarChar).Value = gotReply;
            command.Parameters.Add("@gi", MySqlDbType.VarChar).Value = gotInterv;
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = gotWork;

            connection.OpenAndCloseConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                connection.OpenAndCloseConnection();
                return true;
            }
            else
            {
                connection.OpenAndCloseConnection();
                return false;
            }

        }

        public bool DeleteApplication(int appId)
        {
            //Create SQL command and it's string on what to delete from databased based on the ID it has
            MySqlCommand command = new MySqlCommand();
            String deletingWhere = "DELETE FROM tyohakemukset WHERE ID = @ai";
            command.CommandText = deletingWhere;
            command.Connection = connection.GetConnection();
            command.Parameters.Add("@ai", MySqlDbType.UInt32).Value = appId;

            connection.OpenAndCloseConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                connection.OpenAndCloseConnection();
                return true;
            }
            else
            {
                connection.OpenAndCloseConnection();
                return false;
            }

        }

        public DataTable GetApplications()
        {
            //Create SQL command that selects items from database and fills out a DataTable with the information received
            MySqlCommand command = new MySqlCommand("SELECT ID, employerName, roleName, workAddress, contactInfo, ilmLink, appDate, gotReply, gotInterview, saatuTyo FROM tyohakemukset", connection.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable("tyohakemukset");
            

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
    }
}

