using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HillerService.DataMigration.Entity;
using System.Data.Entity;

namespace HillerService.DataMigration.Logs
{
    public class SThookLog
    {

        STHookEntities db = new STHookEntities();

       
        //Insert Main Log Entry  
        public int insertSTHookLog()
        {

            int LogID = 0;
            try
            {
                STHookEntities context = new STHookEntities();
                
                var STHookLog = context.STHookLog.Add(new STHookLog

                    {
                        TimeStamp = System.DateTime.Now
                    });
                context.SaveChanges();

                //Return LogID
                LogID = STHookLog.LogID;

            }
            catch
            {

            }
            return LogID;
        }


        //Insert Daily Log
        public void insertLog(string description, string logType, string stID, int LogID)
        {
            try
            {
             using (var context = new STHookEntities())
            {
              var STHookLog = context.STHookLog.Find(LogID);

              var DailyLog= context.DailyLog.Add(new DailyLog
                    {
                        ServiceTradeId=stID,
                        Description = description,
                        TimeStamp = System.DateTime.Now,
                        logType = logType
                        
                       
                    });

           STHookLog.DailyLog.Add(DailyLog);

          context.SaveChanges();
           
             }
            }
            catch 
            {

            }

      
        }

        public int getExceptionLog()
        {
            var count = 0;
            try { 

            STHookEntities context = new STHookEntities();

            var logs = (from l in context.DailyLog
                        where (DbFunctions.TruncateTime(l.TimeStamp) == DateTime.Today.Date) && (l.logType == "Exception Error")
                        select new { l.ServiceTradeId, l.TimeStamp, l.Description, l.logType }).ToList();

            count = logs.Count;
            
                }
            catch
            {

            }
            
            return count;

        }

        //Get current connection String for JDE
        public string AS400ConnectionString()
        {
            string connectionString = "";

            STHookEntities context = new STHookEntities();

            var hook = (from h in context.HookCredentials
                        select h
                        ).FirstOrDefault();

            if (hook.runProductionMode==true)
            {
                connectionString= hook.AS400ConnectionString;
            }
            else
            {
                connectionString = hook.AS400ConnectionStringTest;
            }

            return connectionString;
            
        }


        //Get current connection String for JDE
        public HookCredentials ServiceTradeSettings()
        {
            STHookEntities context = new STHookEntities();

            var hook = (from h in context.HookCredentials
                        select h
                        ).FirstOrDefault();


            return hook;
        }

        //Check the Operation Mode for the Service Trade Hook
        public bool CheckOperationMode()
        {
            bool runProductionMode = false;

            STHookEntities context = new STHookEntities();

            var hook = (from h in context.HookCredentials
                        select h
                        ).FirstOrDefault();

            if (hook != null)
            {
                runProductionMode = Convert.ToBoolean(hook.runProductionMode);
            }


            return runProductionMode;
        }
    
    }
}
