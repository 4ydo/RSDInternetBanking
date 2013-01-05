using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSDInternetBanking.BLL
{
    public class ExchangeRates
    {
        public List<ExchangeRateNode> rates;

        public ExchangeRates()
        {
            ExchangeRateNode rate = new ExchangeRateNode(Enums.Сurrency.USD.ToString(), Enums.Сurrency.BYR.ToString(), 8560);
            ExchangeRateNode rate2 = new ExchangeRateNode(Enums.Сurrency.BYR.ToString(), Enums.Сurrency.USD.ToString(), 0.00011627907);
            ExchangeRateNode rate3 = new ExchangeRateNode(Enums.Сurrency.EUR.ToString(), Enums.Сurrency.USD.ToString(), 1.3185);
            ExchangeRateNode rate4 = new ExchangeRateNode(Enums.Сurrency.USD.ToString(), Enums.Сurrency.EUR.ToString(), 0.758437619);
            ExchangeRateNode rate5 = new ExchangeRateNode(Enums.Сurrency.BYR.ToString(), Enums.Сurrency.EUR.ToString(), 0.0000886996629);
            ExchangeRateNode rate6 = new ExchangeRateNode(Enums.Сurrency.EUR.ToString(), Enums.Сurrency.BYR.ToString(), 11274.75);
            rates.Add(rate);
            rates.Add(rate2);
            rates.Add(rate3);
            rates.Add(rate4);
            rates.Add(rate5);
            rates.Add(rate6);
        }
    }
}
