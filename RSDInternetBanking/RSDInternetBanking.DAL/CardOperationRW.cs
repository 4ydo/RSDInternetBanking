using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class CardOperationRW
    {
        public static string Conduct(Dictionary<string,string> _oprtninfo, SqlConnection connect)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM CardOperationa WHERE numoprtn = '" + _oprtninfo["numoprtn"] + "'", connect);
            var r = com.ExecuteScalar();
            if (r == null)
            {
                SqlCommand commandCreate = new SqlCommand("INSERT INTO CardOperationa(numoprtn,dateoprtn,action,region,placetrans,ISO4217trans,amntISO4217trans,amntISO4217c,cnum,status,adrsettleacc) Values(@numoprtn,@dateoprtn,@action,@region,@placetrans,@ISO4217trans,@amntISO4217trans,@amntISO4217c,@cnum,@status,@adrsettleacc)", connect);
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
                return "something wrong is happened in CardOperationRW.Conduct()";
            }
        }

        public static void ChangeStatus();
        public static void CancelOperation();


        public static Dictionary<string, string> ReadHistory(string _cnum, string _dateFrom, string _dateTO, SqlConnection connect)
        {
            Dictionary<string, string> history = new Dictionary<string, string>();
            SqlCommand com = new SqlCommand("SELECT * FROM CardOperations WHERE cnum = '" + _cnum+"' and dateoprtn >='"+_dateFrom+"' and dateoprtn<'"+_dateTO+"'", connect);  
            var card = com.ExecuteReader();
            while (card.Read())
            {
                history.Add("numoprtn", ((string)card["numoprtn"]).TrimEnd());
                history.Add("dateoprtn", ((string)card["dateoprtn"]).TrimEnd());
                history.Add("action", ((string)card["action"]).TrimEnd());
                history.Add("region", ((string)card["region"]).TrimEnd());
                history.Add("placetrans", ((string)card["placetrans"]).TrimEnd());
                history.Add("ISO4217trans", ((string)card["ISO4217trans"]).TrimEnd());
                history.Add("amntISO4217trans", ((string)card["amntISO4217trans"]).TrimEnd());
                history.Add("amntISO4217c", ((string)card["amntISO4217c"]).TrimEnd());
                history.Add("cnum", ((string)card["cnum"]).TrimEnd());
                history.Add("status", ((string)card["status"]).TrimEnd());
                history.Add("adrsettleacc", ((string)card["adrsettleacc"]).TrimEnd());
            }
            card.Close();
            return history; 

        }
        //а надо ли?
/*        public static Dictionary<string, string> ReadHistoryAll(string _cnum, SqlConnection connect)
        {
            return null;
        }
 */
        public static string MoveToArchive(string _cnum, SqlConnection connect)
        {
                Dictionary<string, string> operationinfo = new Dictionary<string,string>();
                SqlCommand com = new SqlCommand("SELECT * FROM CardOperations WHERE cnum = '" + _cnum+"'", connect);
                var card = com.ExecuteReader();
                string rtrn = null; // null means everything is fine
                while (card.Read())
                {
                    operationinfo.Add("numoprtn", ((string)card["numoprtn"]).TrimEnd());
                    operationinfo.Add("dateoprtn", ((string)card["dateoprtn"]).TrimEnd());
                    operationinfo.Add("action", ((string)card["action"]).TrimEnd());
                    operationinfo.Add("region", ((string)card["region"]).TrimEnd());
                    operationinfo.Add("placetrans", ((string)card["placetrans"]).TrimEnd());
                    operationinfo.Add("ISO4217trans", ((string)card["ISO4217trans"]).TrimEnd());
                    operationinfo.Add("amntISO4217trans", ((string)card["amntISO4217trans"]).TrimEnd());
                    operationinfo.Add("amntISO4217c", ((string)card["amntISO4217c"]).TrimEnd());
                    operationinfo.Add("cnum", ((string)card["cnum"]).TrimEnd());
                    operationinfo.Add("status", ((string)card["status"]).TrimEnd());
                    operationinfo.Add("adrsettleacc", ((string)card["adrsettleacc"]).TrimEnd());
                    rtrn = Archive.AddOperation(operationinfo, connect);
                    if (rtrn != null)
                    {
                        return rtrn;
                    }
                }
                card.Close();
            return rtrn; 
        }
    }
}
