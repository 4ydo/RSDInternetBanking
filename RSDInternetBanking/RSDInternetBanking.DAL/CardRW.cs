using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class CardRW
    {
        public static string CreateCard(Dictionary<string, string> _userinfo, SqlConnection connect)
        {
            try
            {
                SqlCommand com = new SqlCommand("SELECT * FROM CardInfo WHERE cnum = '" + _userinfo["cnum"] + "'", connect);
                var r = com.ExecuteScalar();
                if (r == null)
                {
                    SqlCommand commandCreate = new SqlCommand("INSERT INTO CardInfo(cnum,cdateexp,lname,fname,settleacc,pID,pasdateissue,scrtcode,balancelimit) Values(@cnum,@cdateexp,@lname,@fname,@settleacc,@pID,@pasdateissue,@scrtcode,@balancelimit)", connect);
                    commandCreate.Parameters.Add("@cnum", _userinfo["cnum"]);
                    commandCreate.Parameters.Add("@cdateexp", _userinfo["cdateexp"]);
                    commandCreate.Parameters.Add("@lname", _userinfo["lname"]);
                    commandCreate.Parameters.Add("@fname", _userinfo["fname"]);
                    commandCreate.Parameters.Add("@settleacc", _userinfo["settleacc"]);
                    commandCreate.Parameters.Add("@pID", _userinfo["pID"]);
                    commandCreate.Parameters.Add("@pasdateissue", _userinfo["pasdateissue"]);
                    commandCreate.Parameters.Add("@scrtcode", _userinfo["scrtcode"]);
                    commandCreate.Parameters.Add("@balancelimit", _userinfo["balancelimit"]);
                    commandCreate.ExecuteNonQuery();
                    return null;
                }
                else
                {
                    return "this card number has already existed";
                }
            }
            catch { }
            return null;

        }
        

        public static string DeleteCard(string _cnum, SqlConnection connect)
        {
            Dictionary<string, string> cardinfo = ReadByCNum(_cnum, connect);
            string rtrn = null;
            try
            {
                
                rtrn = Archive.AddCard(cardinfo, connect);
                if(rtrn != null)  // !null means something wrong is happened in Archive.AddCard()
                {
                    return rtrn;
                }
                rtrn= CardOperationRW.MoveToArchive(_cnum, connect);
                if (rtrn != null) //!null means something wrong is happened in CardOperationRW.MoveToArchive()
                {
                    return rtrn;
                }


            }
            catch
            {
            }
            return rtrn;
        }
        public static Dictionary<string, string> ReadByCNum(string _cnum, SqlConnection connect)
        {
            Dictionary<string, string> cardinfo = new Dictionary<string, string>();
            try
            {
                
                SqlCommand com = new SqlCommand("SELECT * FROM CardInfo WHERE cnum ='" + _cnum + "'", connect);
                var card = com.ExecuteReader();

                while (card.Read())
                {
                    cardinfo.Add("cnum", ((string)card["cnum"]).TrimEnd());
                    cardinfo.Add("cdateexp", ((string)card["cdateexp"]).TrimEnd());
                    cardinfo.Add("lname", ((string)card["lname"]).TrimEnd());
                    cardinfo.Add("fname", ((string)card["fname"]).TrimEnd());
                    cardinfo.Add("settleacc", ((string)card["settleacc"]).TrimEnd());
                    cardinfo.Add("pID", ((string)card["pID"]).TrimEnd());
                    cardinfo.Add("pasdateissue", ((string)card["pasdateissue"]).TrimEnd());
                    cardinfo.Add("scrtcode", ((string)card["scrtcode"]).TrimEnd());
                    cardinfo.Add("balancelimit", ((string)card["balancelimit"]).TrimEnd());
                }
                card.Close();
            }
            catch { }
            return cardinfo;
        }
        //сделать поиск по личному номеру?! а не по фамлии
        public static Dictionary<string, string> ReadByLastName(string _partname, SqlConnection connect) // return lastname+firstname - cardnumber
        {
            SqlCommand com = new SqlCommand("SELECT * FROM CardInfo WHERE lname LIKE '%" + _partname + "%'", connect);
            var card = com.ExecuteReader();
            Dictionary<string, string> cardinfo = new Dictionary<string, string>();
            while (card.Read())
            {
                string str = ((string)card["fname"]).TrimEnd() + " " + ((string)card["lname"]).TrimEnd();
                cardinfo.Add(str, ((string)card["cnum"]).TrimEnd());
            }
            card.Close();
            return cardinfo;
        }

        public static string SetBalanceLimit(string _cnum, string _balancelimit, SqlConnection connect)
        {
                SqlCommand com = new SqlCommand("SELECT * FROM CardInfo WHERE cnum = '" + _cnum + "'", connect);
                var r = com.ExecuteScalar();
                if (r == null)
                {
                    return "Card doesn't exist";
                }
                SqlCommand setlimit = new SqlCommand("UPDATE CardInfo SET balancelimit ='" +_balancelimit+"'  WHERE cnum = '" + _cnum + "'", connect);
                return null;
        }
    }
}
