using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSDInternetBanking.DAL
{
    public static class Exchange
    {
        public static void SetExchangeRates(Dictionary<string, double> _exchrate)
        {
        }
        public static double GetExchangeRate(string _ISOISO)
        {
            return -1.0;
        }

        public static Dictionary<string, double> GetExchangeRates()
        {
            return null;
        }
    }
}
