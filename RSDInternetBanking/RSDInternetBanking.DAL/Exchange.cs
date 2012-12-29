using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class Exchange
    {
        public static void SetExchangeRates(string _ISO4217from, string _ISO4217to, double _rate, SqlConnection connect)
        {
            try
            {
                
                SqlCommand com = new SqlCommand("SELECT * FROM ExchangeRate WHERE ISO4217from = '" + _ISO4217from + "' and ISO4217to = '" +_ISO4217to +"'" , connect);
                var r = com.ExecuteScalar();
                if (r == null)
                {
                    SqlCommand commandRate = new SqlCommand("INSERT INTO ExchangeRate(ISO4217from, ISO4217to, exchrate) VALUES ('" + _ISO4217from + "','" + _ISO4217to + "','" + _rate + "')", connect);
                    commandRate.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand commandRate = new SqlCommand("UPDATE ExchangeRate SET exchrate = '" + _rate + "' WHERE ISO4217from = '" + _ISO4217from + "' and ISO4217to = '" + _ISO4217to +"'", connect);
                    commandRate.ExecuteNonQuery();

                }
                
            }
            finally 
            { 
                
            }
        }

        public static List<Dictionary<string, string>> GetExchangeRates(SqlConnection connect)
        {
            List<Dictionary<string, string>> allrates = new List<Dictionary<string, string>>();
            try
            {
                
                SqlCommand com = new SqlCommand("SELECT * FROM ExchangeRate", connect);
                var card = com.ExecuteReader();

                while (card.Read())
                {
                    Dictionary<string, string> rate = new Dictionary<string, string>();
                    rate.Add("ISO4217from", ((string)card["ISO4217from"]).TrimEnd());
                    rate.Add("ISO4217to", ((string)card["ISO4217to"]).TrimEnd());
                    rate.Add("exchrate", ((string)card["exchrate"]).TrimEnd());
                    allrates.Add(rate);
                }
                card.Close();
            }
            catch { }
            return allrates;
        }
    }
}
