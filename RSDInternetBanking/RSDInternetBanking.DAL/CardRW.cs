using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class CardRW
    {
        public static string CreateCard(Dictionary<string, string> _userinfo)
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.DataSource = "margarita-vaio\\sqlexpress";
            str.InitialCatalog = "RSDDB";
            str.IntegratedSecurity = true;
            SqlConnection connect = new SqlConnection(str.ToString());
            try
            {
                connect.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM CardInfo WHERE cnum =" + _userinfo["cnum"], connect);
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
            finally 
            { 
                connect.Close(); 
            }
            

        }
        

        public static string DeleteCard(string _cnum)
        {
            Dictionary<string, string> cardinfo = new Dictionary<string,string>();
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.DataSource = "margarita-vaio\\sqlexpress";
            str.InitialCatalog = "RSDDB";
            str.IntegratedSecurity = true;
            SqlConnection connect = new SqlConnection(str.ToString());
            string rtrn = null;
            try
            {
                connect.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM CardInfo WHERE cnum = " + _cnum, connect);
                var card = com.ExecuteReader();
                while (card.Read())
                {
                    cardinfo.Add("cnum",((string)card["cnum"]).TrimEnd());
                    cardinfo.Add("cdateexp", ((string)card["cdateexp"]).TrimEnd());
                    cardinfo.Add("lname", ((string)card["lname"]).TrimEnd());
                    cardinfo.Add("fname", ((string)card["fname"]).TrimEnd());
                    cardinfo.Add("settleacc", ((string)card["settleacc"]).TrimEnd());
                    cardinfo.Add("pID", ((string)card["pID"]).TrimEnd());
                    cardinfo.Add("pasdateissue", ((string)card["pasdateissue"]).TrimEnd());
                    cardinfo.Add("scrtcode", ((string)card["scrtcode"]).TrimEnd());
                    cardinfo.Add("balancelimit", ((string)card["balancelimit"]).TrimEnd());
                    rtrn = Archive.AddCard(cardinfo, connect);
                    if(rtrn != null)  // !null means something wrong is happened in Archive.AddCard()
                    {
                        return rtrn;
                    }
                }
                card.Close();
                rtrn= CardOperationRW.MoveToArchive(_cnum, connect);
                if (rtrn != null) //!null means something wrong is happened in CardOperationRW.MoveToArchive()
                {
                    return rtrn;
                }


            }
            finally
            {
                connect.Close();
            }
            return rtrn;
        }
        public static Dictionary<string, string> ReadByCNum(string _cnum)
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.DataSource = "margarita-vaio\\sqlexpress";
            str.InitialCatalog = "RSDDB";
            str.IntegratedSecurity = true;
            SqlConnection connect = new SqlConnection(str.ToString());
            try
            {
                connect.Open();
            }
            finally
            {
                connect.Close();
            }
            return null;
        }
        public static Dictionary<string, string> ReadByName(string _partname)
        {
            return null;
        }
    }
}
