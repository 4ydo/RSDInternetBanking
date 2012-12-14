using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSDInternetBanking.DAL;

namespace RSDInternetBanking.BLL
{
    public class Card
    {
        public string settleacc { get; private set; }
        public double accbalance { get; private set; }
        public string cardnum { get; private set; }
        public DateTime dateexp { get; private set; }
        public string lastname { get; private set; }
        public string firstname { get; private set; }
        public List<CardOperation> history { get; private set; }


        public Card()
        {
            settleacc = "";//тут зашит код валюты,но таблицу все равно сделать. три буквы - три цифры
            //ISO4217 = ""; // сделать таблицу -код валюты, название валюты, страна. ИСО сделать перечислением.
            accbalance = 0;
            cardnum = "";  // вся инфа о карте зашита в ее номере
            dateexp = new DateTime();
            lastname = "";
            firstname = "";
        }

        public Card(string _cardnum)//возможно, сделать отсюда проверку логина и пароля, и только тогда считывание информации.
        {
            cardnum = _cardnum;
            Dictionary<string, string> userinfo = CardRW.ReadByCNum(cardnum);
            //распарсить все из userinfo
        }
    }
}
