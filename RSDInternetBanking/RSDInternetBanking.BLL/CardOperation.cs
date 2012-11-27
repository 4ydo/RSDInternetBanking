using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSDInternetBanking.BLL
{
    public class CardOperation
    {
        public DateTime dateoprtn { get; set; }
        public string action { get; set; }
        public string region { get; set; }
        public string placetrans { get; set; }  //оставить тут и р\с адресата и инфу о нем?
        public string ISO4217trans { get; set; }
        public double amountISO4217trans { get; set; }
        public double amountISO4217c { get; set; }
        public string status { get; set; }
        public string adrsettleacc { get; set; }


        public CardOperation()
        {
            dateoprtn = new DateTime();
            action = "";
            region = "";
            placetrans = "";
            ISO4217trans = "";
            amountISO4217c = 0;
            amountISO4217trans = 0;
            status = "";
            adrsettleacc = "";
        }
    }
}
