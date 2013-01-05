using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class Loginization
    {
        public static Dictionary<string,string>  UserLoginization(string _login, SqlConnection connect )
        { 
            Dictionary<string, string> logininfo = new Dictionary<string, string>();
            SqlCommand com = new SqlCommand("SELECT * FROM LoginInfo WHERE login ='" + _login + "'", connect);
            var loginreader = com.ExecuteReader();

            while (loginreader.Read())
            {
                logininfo.Add("login", ((string)loginreader["login"]).TrimEnd());
                logininfo.Add("password", ((string)loginreader["password"]).TrimEnd());
                logininfo.Add("cnum", ((string)loginreader["cnum"]).TrimEnd());
                logininfo.Add("lgndateexp", ((string)loginreader["lgndateexp"]).TrimEnd());
            }
            loginreader.Close();
            return logininfo;
        }

        public static Dictionary<string, string> AdminLoginization(string _login, SqlConnection connect)
        {//wrong-неверно,???? иначе - статус (admin, oprtr)
            Dictionary<string, string> admininfo = new Dictionary<string, string>();
            SqlCommand com = new SqlCommand("SELECT * FROM AdminInfo WHERE login ='" + _login + "'", connect);
            var adminreader = com.ExecuteReader();
            //string statusinfo;
            while (adminreader.Read())
            {
                admininfo.Add("login", ((string)adminreader["login"]).TrimEnd());
                admininfo.Add("password", ((string)adminreader["password"]).TrimEnd());
                admininfo.Add("status", ((string)adminreader["status"]).TrimEnd());
            }
            
           // statusinfo = ((string)adminreader["status"]).TrimEnd();
            adminreader.Close();
            return admininfo;
        }

        public static string CreateUser(string _login, string _password, string _cnum, string _lgndateexp, SqlConnection connect)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM LoginInfo WHERE login = '" + _login + "'", connect);
            var r = com.ExecuteScalar();
            if (r == null)
            {
                SqlCommand commandCreate = new SqlCommand("INSERT INTO LoginInfo(login, password,cnum,lgndateexp) Values(@login, @password,@cnum,@lgndateexp)", connect);
                commandCreate.Parameters.Add("@login", _login);
                commandCreate.Parameters.Add("@password", _password);
                commandCreate.Parameters.Add("@cnum", _cnum);
                commandCreate.Parameters.Add("@lgndateexp", _lgndateexp);
                commandCreate.ExecuteNonQuery();
                return null;
            }
            return "This login already exists";
        }

        public static string CreateAdmin(string _login, string _password,string _status , SqlConnection connect)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM LoginInfo WHERE login = '" + _login + "'", connect);
            var r = com.ExecuteScalar();
            if (r == null)
            {
                SqlCommand commandCreate = new SqlCommand("INSERT INTO LoginInfo(login, password,status) Values(@login, @password,@status)", connect);
                commandCreate.Parameters.Add("@login", _login);
                commandCreate.Parameters.Add("@password", _password);
                commandCreate.Parameters.Add("@status", _status);
                commandCreate.ExecuteNonQuery();
                return null;
            }
            return "This login already exists";
        }
    }
}
