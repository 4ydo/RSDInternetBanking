using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RSDInternetBanking.DAL
{
    public static class CardOperationRW
    {
        public static void Conduct(Dictionary<string,string> _operation)
        {
        }
        public static Dictionary<string, string> ReadHistoryTwenty(string _cardnum)
        {
            return null; 
        }
        public static Dictionary<string, string> ReadHistoryAll(string _cardnum)
        {
            return null;
        }
        public static string MoveToArchive(string _cnum, SqlConnection connect)
        {
                Dictionary<string, string> operationinfo = new Dictionary<string,string>();
                SqlCommand com = new SqlCommand("SELECT * FROM CardOperations WHERE cnum = " + _cnum, connect);
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
