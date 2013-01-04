using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using RSDInternetBanking.DAL;

namespace RSDInternetBanking.BLL
{
    class Login
    {
        public bool User (string _login, string _password)
        {
            Connection connect = new Connection();
            connect.Open();
            try
            {
                Dictionary<string, string> userinfo = Loginization.UserLoginization(_login, connect._connect);
                DateTime dtexp = DateTime.Parse(userinfo["lgndateexp"]);
                if ((_password == userinfo["password"]) && ((DateTime.Today.CompareTo(dtexp)) == 0))
                {
                    return true;
                }
                return false;
            }
            finally
            {
                connect.Close();
            }
        }

        public string Admin(string _login, string _password)
        {
            Connection connect = new Connection();
            connect.Open();
            try
            {
                Dictionary<string, string> admininfo = Loginization.AdminLoginization(_login, connect._connect);
                if (_password == admininfo["password"])
                {
                    return admininfo["status"];
                }
                return null;
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
