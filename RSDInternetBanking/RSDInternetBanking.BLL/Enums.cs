using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSDInternetBanking.BLL
{ 
    public static class Enums  //выдача номера карточки по определенной схеме
    {
        public enum CardType
        {
            Debit = 10,
            Credit = 11
        }

        public enum BankNumbers
        {
            BankID = 5654,
            BranchOffice1 = 11,
            BranchOffice2 = 12,
            BranchOffice3 = 13
        }

        public enum Сurrency
        {
            BYR = 974,
            GBP = 826,
            CAD = 124,
            CZK = 203,
            EUR = 978,
            FRF = 250,
            DEM = 276,
            IEP = 372,
            ITL = 380,
            LVL = 428,
            LTL = 440,
            MXN = 484,
            PLN = 985,
            RUB = 643,
            SKK = 703,
            ESP = 724,
            CHF = 756,
            UAH = 980,
            USD = 840
        }
        
    }
}
