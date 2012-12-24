using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class Connection
    {
        public static SqlConnection Open()
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.DataSource = "margarita-vaio\\sqlexpress";
            str.InitialCatalog = "RSDDB";
            str.IntegratedSecurity = true;
            SqlConnection connect = new SqlConnection(str.ToString());
            connect.Open();
            return connect;
        }
        public static void Close(SqlConnection connect)
        {
            connect.Close();
        }
    }
}
