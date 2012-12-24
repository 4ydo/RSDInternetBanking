using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class Loginization
    {
        public static string  UserLoginization(string _login, string _password, SqlConnection connect )
        { //проверить также срок действия пароля null-неверно, строка-верно
            return null;
        }

        public static string AdminLoginization(string _login, string _password, SqlConnection connect)
        {//null-неверно, иначе - статус (admin, oprtr)
            return null;
        }
    }
}
