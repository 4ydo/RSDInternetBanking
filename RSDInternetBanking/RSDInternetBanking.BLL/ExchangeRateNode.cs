using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSDInternetBanking.BLL
{
    public class ExchangeRateNode
    {
        public string ISO4217from;
        public string ISO4217to;
        public double rate;
        public ExchangeRateNode()
        {
        }
        public ExchangeRateNode(string _ISO4217from, string _ISO4217to, double _rate)
        {
            ISO4217from= _ISO4217from;
            ISO4217to = _ISO4217to;
            rate = _rate;
        }
    }
}
