using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public class Connection
    {
        public SqlConnection _connect;
        public Connection()
        {
        }
        public void Open()
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.DataSource = "margarita-vaio\\sqlexpress";
            str.InitialCatalog = "RSDDB";
            str.IntegratedSecurity = true;
            _connect = new SqlConnection(str.ToString());
            _connect.Open();
        }
        public void Close()
        {
            _connect.Close();
        }
    }
}
