using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSDInternetBanking.DAL;
using System.Data.SqlClient;

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
        public double balancelimit {get; private set;}

        public Card(string _settleacc, double _accbalance, string _cardnum, DateTime _dateexp, string lname, string fname)
        {
            settleacc = _settleacc;
            accbalance = _accbalance;
            cardnum = _cardnum;
            dateexp = _dateexp;
            lastname = lname;
            firstname = fname;
            history = null;
            int type = int.Parse(cardnum.Substring(7,8));
            switch (type)
            {
                case (int)Enums.CardType.Credit:
                    balancelimit = -100;
                    break;
                case (int)Enums.CardType.Debit:
                    balancelimit = 0;
                    break;
            }
        }
        public void LoadHistory(List<CardOperation> _hist)
        {
            history = _hist;
        }
        public Card()
        {
            settleacc = "";//тут зашит код валюты,но таблицу все равно сделать. три буквы - три цифры
            accbalance = 0;
            cardnum = "";  // вся инфа о карте зашита в ее номере
            dateexp = new DateTime();
            lastname = "";
            firstname = "";
            history = null;
        }

        public Card(string _cardnum)//возможно, сделать отсюда проверку логина и пароля, и только тогда считывание информации.
        {
            cardnum = _cardnum;
            Connection connect = new Connection();
            connect.Open();
            Dictionary<string, string> userinfo = CardRW.ReadByCNum(cardnum,connect._connect);
            connect.Close();
            //распарсить все из userinfo
        }

        public void SaveCard()
        {
            Dictionary<string, string> cardinfo = new Dictionary<string, string>();
            cardinfo.Add("cnum", cardnum);
            cardinfo.Add("cdateexp", dateexp.ToString());
            cardinfo.Add("lname",lastname);
            cardinfo.Add("fname",firstname);
            cardinfo.Add("settleacc",settleacc);
            cardinfo.Add("pID","");
            cardinfo.Add("pasdateissue","12-02-2030");
            cardinfo.Add("scrtcode","013");
            cardinfo.Add("balancelimit", balancelimit.ToString());
            Connection connect = new Connection();
            connect.Open();
            CardRW.CreateCard(cardinfo, connect._connect);
            connect.Close();
        }


    }
}
