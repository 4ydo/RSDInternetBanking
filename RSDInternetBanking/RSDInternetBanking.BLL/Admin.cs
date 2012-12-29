using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSDInternetBanking.BLL
{
    public class Admin
    {
        public void SetExchangeRate()
        {
        }
        public void CreateNewCard(string _settleacc, string _fname, string _lname,string _pID,string _pasdateissue, string _scrtcode)
        {
        }

        //return number of control sum
        public int CheckCardNumber(string _cnum)
        {
            int numbercount = 15; //15 signs in card-number (without control number)
            int[] cardnumber = new int[16];
            char[] numberchar = _cnum.ToCharArray();
            int sum = 0;
            for (int i = 0; i < numbercount; i++ )
            {
                
                cardnumber[i] = (byte)numberchar[i];
                sum = sum + cardnumber[i];
            }
            for (int i = 0; i < numbercount; i = i + 2)
            {
                int temp = (cardnumber[i] * 2)%9;
                sum = sum - cardnumber[i] + temp;
            }
            int controlnum = (10 - (sum % 10))%10;
            return controlnum;
        }
        
    }
}
