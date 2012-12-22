using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class Archive  
    {
        public static Dictionary<string, string> GetCardInfo()
        {
            return null; 
        }

        public static string AddCard( Dictionary<string, string> _cardinfo, SqlConnection connect)
        {           
            SqlCommand com = new SqlCommand("SELECT * FROM CardInfoArchive WHERE cnum =" + _cardinfo["cnum"], connect);
            var r = com.ExecuteScalar();
            if (r == null)
            {
                SqlCommand commandCreate = new SqlCommand("INSERT INTO CardInfoArchive(cnum,cdateexp,lname,fname,settleacc,pID,pasdateissue,scrtcode,balancelimit) Values(@cnum,@cdateexp,@lname,@fname,@settleacc,@pID,@pasdateissue,@scrtcode,@balancelimit)", connect);
                commandCreate.Parameters.Add("@cnum", _cardinfo["cnum"]);
                commandCreate.Parameters.Add("@cdateexp", _cardinfo["cdateexp"]);
                commandCreate.Parameters.Add("@lname", _cardinfo["lname"]);
                commandCreate.Parameters.Add("@fname", _cardinfo["fname"]);
                commandCreate.Parameters.Add("@settleacc", _cardinfo["settleacc"]);
                commandCreate.Parameters.Add("@pID", _cardinfo["pID"]);
                commandCreate.Parameters.Add("@pasdateissue", _cardinfo["pasdateissue"]);
                commandCreate.Parameters.Add("@scrtcode", _cardinfo["scrtcode"]);
                commandCreate.Parameters.Add("@balancelimit", _cardinfo["balancelimit"]);
                commandCreate.ExecuteNonQuery();
                return null;   //null means everything is fine
            }
            else
            {
                return "something wrong is happened in Archive.AddCard";
            }
            
        }

        public static string AddOperation(Dictionary<string, string> _oprtninfo, SqlConnection connect)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM CardOperationArchive WHERE numoprtn =" + _oprtninfo["numoprtn"], connect);
            var r = com.ExecuteScalar();
            if (r == null)
            {
                SqlCommand commandCreate = new SqlCommand("INSERT INTO CardInfoArchive(numoprtn,dateoprtn,action,region,placetrans,ISO4217trans,amntISO4217trans,amntISO4217c,cnum,status,adrsettleacc) Values(@numoprtn,@dateoprtn,@action,@region,@placetrans,@ISO4217trans,@amntISO4217trans,@amntISO4217c,@cnum,@status,@adrsettleacc)", connect);
                commandCreate.Parameters.Add("@numoprtn", _oprtninfo["numoprtn"]);
                commandCreate.Parameters.Add("@dateoprtn", _oprtninfo["dateoprtn"]);
                commandCreate.Parameters.Add("@action", _oprtninfo["action"]);
                commandCreate.Parameters.Add("@region", _oprtninfo["region"]);
                commandCreate.Parameters.Add("@placetrans", _oprtninfo["placetrans"]);
                commandCreate.Parameters.Add("@ISO4217trans", _oprtninfo["ISO4217trans"]);
                commandCreate.Parameters.Add("@amntISO4217trans", _oprtninfo["amntISO4217trans"]);
                commandCreate.Parameters.Add("@amntISO4217c", _oprtninfo["amntISO4217c"]);
                commandCreate.Parameters.Add("@cnum", _oprtninfo["cnum"]);
                commandCreate.Parameters.Add("@status", _oprtninfo["status"]);
                commandCreate.Parameters.Add("@adrsettleacc", _oprtninfo["adrsettleacc"]);
                commandCreate.ExecuteNonQuery();
                return null;
            }
            else
            {
                return "something wrong is happened in Archive.AddOperation";
            }
        }
    }
}
