using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using HillerService.DataMigration.Entity;
using System.Data.Entity;

namespace HillerService.DataMigration.Email
{
    class EmailManager
    {


        //Send notification after the hook run is completed.
        public void sendEmail()
        {
            string message = "";
            string subject = "ST Hook alerts";

            
            //Get SMTP Settings Information

            STHookEntities context = new STHookEntities();

            try 
            {

                //Get Smtp Settings

                var smtpSettings = (from s in context.SMTPSettings
                                    select s                                
                                    ).FirstOrDefault();

              
              

            MailMessage mail = new MailMessage("notifications@hillercompanies.com", smtpSettings.SMTPNotificationEmail);
            SmtpClient client = new SmtpClient();

            client.Port =Convert.ToInt32(smtpSettings.SMTPPort);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = smtpSettings.SMTPHost;
            client.EnableSsl =Convert.ToBoolean(smtpSettings.SMTPEnableSSL);
            client.Credentials = new System.Net.NetworkCredential(smtpSettings.SMTPUsername, smtpSettings.SMTPPassword);

            mail.Subject = subject;

           //Get Main Log
            var mainLog = (from l in context.STHookLog
                           orderby l.LogID descending
                           select l
                                   ).FirstOrDefault();

    

            if (mainLog != null)
            {
            var logs = (from l in context.DailyLog
                        where l.STHookLog.LogID==mainLog.LogID && (l.logType.Contains("Error"))
                        select new { l.ServiceTradeId, l.TimeStamp, l.Description, l.logType }).ToList();

             string exceptionLines = " " +Environment.NewLine;

            if (logs != null)

            {
                message = "The ST Migration completed with " + logs.Count.ToString() + " Exceptions" + Environment.NewLine;
                if (logs.Count >= 1)
                {
                    // message = "The Migration completed with " + logs.Count.ToString() + " Exceptions" + Environment.NewLine;
             

                foreach (var item in logs)
                {
                    exceptionLines = exceptionLines + string.Format("Service Trade ID: {0} " + Environment.NewLine + "Description: {1}" + Environment.NewLine + "Time Stamp: {2} " +Environment.NewLine + "Log Type: {3}", item.ServiceTradeId.ToString(), item.Description,
                                                        item.TimeStamp, item.logType.ToString()) + Environment.NewLine + Environment.NewLine; 
                   // message = message + item.Description + Environment.NewLine;
                }
                

                }
            }

            


                message = message + exceptionLines;
             
              
            }
            else
            {
              //  message = "Migration completed successfully.";

            }


            mail.Body = message;
            mail.BodyEncoding=UTF8Encoding.UTF8;

            client.Send(mail);

                }
            catch
            {

            }
        }

    }

   
}
