using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HillerService.DataMigration.ServiceTradeIntegration
{
    public static class Constants
    {
       

        public static string SALESMAN984 { get { return "SALESMAN984"; } }
        public static string SALESMAN209 { get { return "SALESMAN209"; } }

        public static int LOGID
        {
            get
            {
                Logs.SThookLog st = new Logs.SThookLog();
                return st.insertSTHookLog();
            }
        }
    }
}
