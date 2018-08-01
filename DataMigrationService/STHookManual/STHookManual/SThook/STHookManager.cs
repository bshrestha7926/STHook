using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HillerService.DataMigration.Entity;
using Telerik.WinControls.UI;
using System.Windows.Forms;

using HillerService.DataMigration.ServiceTradeIntegration;
using HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts;

namespace STHookAdmin.SThook
{
    class STHookManager
    {

        IApiManager serviceTrade = new ServiceTradeAPIManager();

        //Query Top 7 Main Log entry
        public void getMainLog(RadGridView rdg)
        {
            STHookEntities context = new STHookEntities();

            var log = (from l in context.STHookLog.Take(7)
                       orderby l.LogID descending
                       select new { l.LogID, l.TimeStamp }).ToList();
            rdg.DataSource = log;
            bestFitRadGridView(rdg);
        }



        //Auto Arrange Columns in gridview
        public void bestFitRadGridView(RadGridView rgv)
        {
            foreach (GridViewColumn col in rgv.Columns)
            {
                col.BestFit();
                col.AutoSizeMode = BestFitColumnMode.AllCells;
            }
        }


        //Get Log by Date
       public void getLogByDate(DateTime date, RadGridView rdLog)
        {
            STHookEntities context = new STHookEntities();

            var logs = (from l in context.DailyLog
                        where DbFunctions.TruncateTime(l.TimeStamp) == date.Date
                        select new { l.ServiceTradeId, l.TimeStamp, l.Description, l.logType }).ToList();
            rdLog.DataSource = logs;
            bestFitRadGridView(rdLog);
        }

        //Get Logs by log ID
        public  void getLogsByLogId(int logId, RadGridView rdLog, Label lblmain)
        {
            STHookEntities context = new STHookEntities();

            var logs = (from l in context.DailyLog
                        where (l.STHookLog.LogID) == logId
                        select new { l.ServiceTradeId, l.TimeStamp, l.Description, l.logType }).ToList();

            var mainLog = (from ml in context.STHookLog
                           where ml.LogID == logId
                           select ml).FirstOrDefault();

            if (mainLog != null)
            {
                lblmain.Text = "Log ID (" + mainLog.LogID.ToString() + ") / " + mainLog.TimeStamp.ToString();
                lblmain.Refresh();
            }

            rdLog.DataSource = logs;
            bestFitRadGridView(rdLog);
        }


        //Get Logs by log ID
        public List<DailyLog> getLogsByLogIdManual(int logId)
        {
            STHookEntities context = new STHookEntities();

            var logs = (from l in context.DailyLog
                        where (l.STHookLog.LogID) == logId
                        select l
                        ).ToList();

            

            return logs;
           
           }


        //Get ID of logs that ran last
        public int getLogIDforLastRun()
        {
            STHookEntities context = new STHookEntities();

            var log = (from l in context.STHookLog
                       orderby l.LogID descending
                       select l
                       ).FirstOrDefault();


            return log.LogID;
        }



        //Get the SMTP Settings Detail
        public SMTPSettings getSMTPDetail()
        {
            STHookEntities context = new STHookEntities();

            var smtpSettings = (from s in context.SMTPSettings
                                select s
                                ).FirstOrDefault();

            return smtpSettings;

        }


        //Update SMTP Settings
        public bool updateSMTPSettings(int Id, bool enableSSL, string port, string host, string username, string email, string password)
        {
            bool success = false;

            STHookEntities context = new STHookEntities();

            var smtpSettings = context.SMTPSettings.SingleOrDefault(s => s.id == Id);

            try
            {
                if (smtpSettings != null)
                {
                    smtpSettings.SMTPEnableSSL = enableSSL;
                    smtpSettings.SMTPPort = port;
                    smtpSettings.SMTPHost = host;
                    smtpSettings.SMTPUsername = username;
                    smtpSettings.SMTPNotificationEmail =email;
                    smtpSettings.SMTPPassword = password;
                    context.SaveChanges();
                    success = true;
                }
            }

            catch
            {
                success = false;
            }

            return success;
        }

//get Hook Credentials
       public HookCredentials getHookSettings()
        {
            STHookEntities context = new STHookEntities();


            var hookSettings = (from h in context.HookCredentials
                                select h
                                ).FirstOrDefault();


            return hookSettings;

        }


        //Update Hook Settings
       public bool updateHookCredentials(int Id, bool runProductionMode, string uri, string username, string password, string connectionstring, string uriTest, string usernameTest,
                                              string passwordTest, string connectionstringTest)
       {
           bool success = false;

           STHookEntities context = new STHookEntities();

           var hookSettings = context.HookCredentials.SingleOrDefault(h => h.id == Id);


           try
           {
               if (hookSettings != null)
               {
                   hookSettings.runProductionMode = runProductionMode;
                   hookSettings.ServiceTradeURI =uri;
                   hookSettings.ServiceTradeUserName =username;
                   hookSettings.ServiceTradePassword = password;
                   hookSettings.AS400ConnectionString = connectionstring;


                   hookSettings.ServiceTradeURITest =uriTest;
                   hookSettings.ServiceTradeUserNameTest =usernameTest;
                   hookSettings.ServiceTradePasswordTest = passwordTest;
                   hookSettings.AS400ConnectionStringTest =connectionstringTest;
                   context.SaveChanges();
                   success = true;
               }
           }

           catch
           {
               success = false;
           }

           return success;

       }


        //Search Individual Invoice from Service Trade
       public List<FSTINV> searchInvoice(string invoiceId)
       {
           List<FSTINV> Invoices = new List<FSTINV>();

           var invoice = serviceTrade.GetInvoice(invoiceId);

           if (invoice != null)
           {
                 Invoices.Add(invoice);
           }

           return Invoices;

       }


       //Search Individual Invoice from Service Trade
       public List<Tag> SearchTags(string invoiceId)
       {
           //List<Tag> Tags = new List<Tag>();

           var Tags= serviceTrade.GetTags(invoiceId);

          
           return Tags;

       }

       //Search Tags
       public List<string> Tags (string invoiceId)
       {
           
           List<string> Tags = new List<string>();

           var invoice = serviceTrade.GetInvoice(invoiceId);

           if (invoice != null)
           {
               Tags = invoice.Tags;
              //Tags.Add(invoice.Tags);
           }

           return Tags;

       }

        //Get All Sent Invoices from Service Trade
       public List<FSTINV> GetAllInvoices()
       {
          List<FSTINV> Invoices = new List<FSTINV>();
           try
           {
              Invoices = serviceTrade.GetInvoices();
           }
           catch
           {

           }
                  

           return Invoices;

       }






    }
}
