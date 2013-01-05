using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSDInternetBanking.DAL;

namespace RSDInternetBanking.BLL
{
    public class Admin
    {
        public void SetExchangeRate()
        {
            //GetCursOnDate(DateTime.Today());
            ExchangeRates rates = new ExchangeRates();
            Connection connect = new Connection();
            connect.Open();
            foreach (var k in rates.rates)
            {
                Exchange.SetExchangeRates(k.ISO4217from, k.ISO4217to, k.rate, connect._connect);
            }
            connect.Close();

        }


        private string CreateCardNumber(string _type, int _branchOffice)
        {
            string cardnum = ((int)Enums.BankNumbers.BankID).ToString();
            switch (_branchOffice)
            {
                case 1:
                    cardnum = cardnum + ((int)Enums.BankNumbers.BranchOffice1).ToString();
                    break;
                case 2:
                    cardnum = cardnum + ((int)Enums.BankNumbers.BranchOffice2).ToString();
                    break;
                case 3:
                    cardnum = cardnum + ((int)Enums.BankNumbers.BranchOffice3).ToString();
                    break;
                default:
                    cardnum = cardnum + ((int)Enums.BankNumbers.BranchOffice1).ToString();
                    break;
            }
            cardnum = cardnum + _type;
            cardnum = cardnum + CreateUniqueCardNumber();
            cardnum = cardnum + ControlCardNumber(cardnum);
            return cardnum;
        }

        private string CreateUniqueCardNumber()
        {
            Connection connect = new Connection();
            connect.Open();
            string lastnum = CardRW.GetLastCardNumber(connect._connect);
            int num =int.Parse(lastnum.Substring(9, 15));
            num = num + 1;
            connect.Close();
            return num.ToString();
        }

        public void CreateNewCard(string _settleacc, string _fname, string _lname, string _type, int _branchOffice)
        {
            string type = "";
            switch (_type)
            {
                case "Credit":
                    type = ((int)Enums.CardType.Credit).ToString();
                    break;
                case "Debit":
                    type = ((int)Enums.CardType.Debit).ToString();
                    break;
                default:
                    type = ((int)Enums.CardType.Debit).ToString();
                    break;
            }
            string cnum = CreateCardNumber(type, _branchOffice);
            DateTime _dateexp = DateTime.Today.AddYears(4);
            Card _card = new Card(_settleacc, 0, cnum, _dateexp, _lname, _fname);
            

        }

        //return number of control sum
        public int ControlCardNumber(string _cnum)
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
