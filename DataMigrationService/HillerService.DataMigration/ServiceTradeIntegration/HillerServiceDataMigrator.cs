using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Globalization;
using DataMigrationService.Utilities.Interfaces;
using DataMigrationService.Utilities.EventHandlers;
using IBM.Data.DB2.iSeries;
using HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts;
using HillerService.DataMigration.Test;
using HillerService.DataMigration.Entity;


namespace HillerService.DataMigration.ServiceTradeIntegration
{
    public class HillerServiceDataMigrator : IDataMigrator, IMigratorEvents
    {

        bool active;
        bool forceStop;
        Configuration configuration;
        IApiManager serviceTrade;
        Logs.SThookLog st;
       
        
       // private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private DateTime unixBaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public string Name { get; set; }

       
        public string SQLConnectionString { get { return configuration.ConnectionStrings.ConnectionStrings["SQL"].ConnectionString; } }
       // public string AS400ConnectionString { get { return configuration.ConnectionStrings.ConnectionStrings["AS400"].ConnectionString; } }


        //ODBC Connectionstring 
        public string AS400ConnectionString 
        { 
            get 
            { 
             // return configuration.ConnectionStrings.ConnectionStrings["AS400"].ConnectionString; 
               return st.AS400ConnectionString();
            } 
        }



       public static int LogId;

        //This will tell the service when the migration is done
        public event MigrationStop DataMigrationStop;

        public HillerServiceDataMigrator()
        {
            Name = "Hiller Service Data Migrator";

            ExeConfigurationFileMap configurationMap = new ExeConfigurationFileMap() { ExeConfigFilename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "HillerService.DataMigration.config") };
            configuration = ConfigurationManager.OpenMappedExeConfiguration(configurationMap, ConfigurationUserLevel.None);         

        }

        public void PerformMigration()
        {
            if (!active)
            {
                active = true;

                //Get the IP Address of the machine/Server running the Hook
                IPHostEntry host =  Dns.GetHostEntry(Dns.GetHostName());
                string ipAdd = "?";
                foreach(IPAddress ip in host.AddressList)
                {
                    if(ip.AddressFamily.ToString() == "InterNetwork")
                        ipAdd = ip.ToString();
                }
                
              st = new Logs.SThookLog();
              Email.EmailManager emailManager = new Email.EmailManager();

              
                                
              LogId = st.insertSTHookLog();

              st.insertLog("Starting Migration from IP Address: " + ipAdd, "Info", "NA", LogId);
                                
              serviceTrade = new ServiceTradeAPIManager();

                try
                {                    
                    //Open Connection to the JDE
                    using (iDB2Connection db2Connection = new iDB2Connection(AS400ConnectionString))
                    using (iDB2Command db2Command = new iDB2Command() { Connection = db2Connection })
                    {
                        
                        db2Connection.Open();

                        st.insertLog("Connection " + db2Connection.ConnectionString, "ODBC Connection", "NA", LogId);

                         //Migration of Companies from JDE to service trade is currently disabled. This generates 600 404 not found error.
                        //MigrateUnprocessedCompaniesFromJDE(db2Command);

                        //Migration of Location from JDE to service trade is currently disabled. This generates 600 404 not found error.
                       // MigrateUnprocessedLocations(db2Command);

                  GetInvoicesFromServiceTrade(db2Command);
                  SendInvoiceUpdates(db2Command);
                  db2Connection.Close();
                        
                    }
                }
                catch (ThreadAbortException)
                {
                    // do nothing
                }
                catch (Exception ex)
                {
                    st.insertLog(ex.ToString(), "Exception Error", "NA", LogId);

                }
                finally
                {
                    active = false;
                    st.insertLog("Migration Completed", "Info", "NA", LogId);

                  emailManager.sendEmail();
                                      
                }

                if (DataMigrationStop != null)
                    DataMigrationStop(this, new MigrationEventArgs(true));
            }
        }
        #region Company
        private void MigrateUnprocessedCompaniesFromJDE(iDB2Command db2Command)
        {
            Dictionary<string, Company> jdeCompList = new Dictionary<string, Company>();

            st.insertLog("Migrating Companies", "Info", "NA", LogId);

           iDB2DataReader reader;

            using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction())
            {
                db2Command.Transaction = db2Transaction;

                db2Command.CommandText = string.Format("SELECT * FROM FSTCOMP WHERE SCSTAT != '{0}'", "P");

                reader = db2Command.ExecuteReader();
                
                while (reader.Read())
                {
                    Company temp = new Company();

                    temp.scan8 = (string)reader["SCAN8"];
                    temp.type = Char.Parse((string)reader["SCACTN"]);
                    //Company Name
                    temp.name = ((string)reader["SCNAME"]).Trim();
                    temp.addressStreet = ((string)reader["SCADDR"]).Trim();
                    temp.addressCity = ((string)reader["SCCITY"]).Trim();
                    temp.addressState = ((string)reader["SCST"]).Trim();
                    temp.addressPostalCode = ((string)reader["SCZIP"]).Trim();
                    temp.customer = Int32.Parse((string)reader["SCCUST"]) == 1 ? true : false;
                    temp.vendor = Int32.Parse((string)reader["SCVEND"]) == 1 ? true : false;
                    temp.phoneNumber = ((string)reader["SCPHON"]).Trim();
                    temp.status = ((string)reader["SCSSTS"]).Trim();

                    jdeCompList.Add((string)reader["SCAN8"], temp);
                }

                reader.Close();               
                db2Command.Transaction.Dispose();
            }

            if (jdeCompList.Count > 0)
            {
                st.insertLog(string.Format("Found {0} companies for update", jdeCompList.Count), "Info", "NA", HillerServiceDataMigrator.LogId);
            
                foreach (var jde in jdeCompList)
                {
                    st.insertLog("Migrating " + jde.Value.name, "Info", "NA", HillerServiceDataMigrator.LogId);

                    bool success = jde.Value.type == 'A' ? serviceTrade.AddCompany(jde.Value) : serviceTrade.UpdateCompany(jde.Value);
                    if (success)
                    {
                       // log.Debug("Updating Migrated Companies.");
                        using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction(IsolationLevel.Chaos))
                        {
                            db2Command.Transaction = db2Transaction;
                            db2Command.CommandText = "UPDATE FSTCOMP SET SCSTAT = @scstat WHERE SCAN8 = @key";
                            db2Command.DeriveParameters();
                            db2Command.Parameters["@scstat"].Value = 'P';
                            db2Command.Parameters["@key"].Value = jde.Key;

                           // log.Debug(db2Command.CommandText);

                            try
                            {
                                db2Command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                              //  log.Error("Company update unsuccessful ", ex);
                            }

                            db2Command.Transaction.Dispose();
                        }
                    }
                }
            }
            else
            {
               // log.Info("No company found for processing.");
            }           
        }

        #endregion

        #region Location
        private void MigrateUnprocessedLocations(iDB2Command db2Command)
        {
            Dictionary<string, Location> jdeLocList = new Dictionary<string, Location>();
            
           // log.Debug("Migrating Location");

            using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction())
            {
                db2Command.Transaction = db2Transaction;
                db2Command.CommandText = string.Format("SELECT * FROM FSTLOCN WHERE SLSTAT != '{0}'", "P");
                iDB2DataReader reader = db2Command.ExecuteReader();

                while (reader.Read())
                {
                    Location temp = new Location();

                    temp.slan8 = ((string)reader["SLAN8"]).Trim();
                    temp.slpan8 = ((string)reader["SLPAN8"]).Trim();
                    temp.name = ((string)reader["SLNAME"]).Trim();
                    temp.addressStreet = ((string)reader["SLADDR"]).Trim();
                    temp.addressCity = ((string)reader["SLCITY"]).Trim();
                    temp.addressState = ((string)reader["SLST"]).Trim();
                    temp.addressPostalCode = ((string)reader["SLZIP"]).Trim();
                    temp.phoneNumber = ((string)reader["SLPHON"]).Trim();
                    temp.type = Char.Parse(((string)reader["SLACTN"]).Trim());
                    temp.officeIds = new int[]{Int32.Parse(((string)reader["SLMCU"]).Trim())};

                    jdeLocList.Add(temp.slan8, temp);
                }

                reader.Close();
                db2Command.Transaction.Dispose();
            }

            if (jdeLocList.Count > 0)
            {
               // log.Info(string.Format("Found {0} locations for update", jdeLocList.Count));
                foreach (var jde in jdeLocList)
                {
                   // log.Debug("Migrating " + jde.Value.name);
                    bool success = jde.Value.type == 'A' ? serviceTrade.AddLocation(jde.Value) : serviceTrade.UpdateLocation(jde.Value);
                    if (success)
                    {
                        using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction(IsolationLevel.Chaos))
                        {
                            db2Command.Transaction = db2Transaction;
                            db2Command.CommandText = string.Format("UPDATE FSTLOCN SET SLSTAT = @slstat WHERE SLAN8 = @key", jde.Key);
                            db2Command.DeriveParameters();
                            db2Command.Parameters["@slstat"].Value = 'P';
                            db2Command.Parameters["@key"].Value = jde.Key;

                            try
                            {
                                db2Command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                           //     log.Error("Location update unsuccessful ", ex);
                            }

                            db2Command.Transaction.Dispose();
                        }
                    }
                }
            }
            else
            {
              //  log.Info("No location found for processing.");
            }
        }
        #endregion

        #region Invoice

        //get Invoices
        private void GetInvoicesFromServiceTrade(iDB2Command db2Command)
        {
             
            //Get the List of Inovices from the Service Trade
            List<FSTINV> InvoiceList = serviceTrade.GetInvoices();

            st.insertLog("Total Invoices from Service Trade with sent status : " + InvoiceList.Count(), "Info", "NA", LogId);
            
            foreach (FSTINV inv in InvoiceList)
            {

                 //For each invoice check to see if invoice already exists on the JDE side
                if (! InvoiceExists(db2Command, inv.SIID)) //If Invoice does not exists
                {


                    //Get invoice customer's company external id
                    inv.Customer.External = new ExternalId() { JdeId = serviceTrade.GetCompanyExternalId(inv.Customer.CompanyId) };
                  
                    //Since the assigned technician is coming from the appointment endpoint, we need to make another api call
                 
                    //Get the Technician associated with the Invoice\
                    //based on Job Number
                    inv.Technician = serviceTrade.GetTechnician(inv.Job.Number);

                    //Get customer location's external id
                    inv.Location.External = new ExternalId() { JdeId = serviceTrade.GetLocationExternalId(inv.Location.LocationId) };

                    //Get the servicing office for this invoice location
                    inv.ServicingOffice = serviceTrade.GetServicingOffice(inv.Location.LocationId);

                    //Get sales number tag
                    inv.Tags = serviceTrade.GetSalesNumber(inv);

                    //Get public comments
                    inv.CommentsList = serviceTrade.GetInvoiceComments(inv);   

                    //Check for FPMAR

                    if (inv.Job != null)
                    {
                         inv.FPMARActive = serviceTrade.GetFPMAR(inv.Job.JobId);
                    }
                  

                    //Insert invoice into FSTINV table
                    InsertInvoiceToJDE(db2Command, inv);

                    //Check if there are comments for this invoice
                    try
                    {
                        if (!string.IsNullOrEmpty(inv.Notes))
                        InsertComments(db2Command, inv);
                    }
                    catch
                    {
                        st.insertLog("The comments/notes are not in the valid format. ", "Exception Error", inv.SIID, LogId);
                    }
                   

                    //Set the invoice to Pending Accouting in ST first.                  
                    serviceTrade.SetInvoiceToPending(inv.SIID);


                    //9/1/2015 JC: Only set the invoice status to pending accounting until a JDE number is assigned
                    //Set invoice to processed in ServiceTrade
                    //serviceTrade.SetInvoiceToProcessed(inv);
                }
                else
                {


                    st.insertLog(string.Format("Invoice {0} already exists in JDE.", inv.SIID), "Info", inv.SIID.ToString(), LogId);

                    //Set the invoice to Pending Accouting in ST first.
                    serviceTrade.SetInvoiceToPending(inv.SIID);

                    //9/1/2015 JC: Only set the invoice status to pending accounting until a JDE number is assigned
                    //Set invoice to processed in ServiceTrade
                    //inv.Status = "processed";
                    //serviceTrade.SetInvoiceToProcessed(inv);

                }
            }
        }

        //This function returns true if the invoice found in the FSTINV table
        private bool InvoiceExists(iDB2Command db2Command, string st)
        {
            bool exists = false;

            using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction())
            {
                db2Command.Transaction = db2Transaction;
                db2Command.CommandText = string.Format("SELECT * FROM FSTINV WHERE SIID = {0}", st);

                iDB2DataReader reader = db2Command.ExecuteReader();

                exists = reader.HasRows;

                reader.Close();
                db2Command.Transaction.Dispose();
            }

            return exists;
        }


        //This function inserts the invoice into the FSTINV Table
        private void InsertInvoiceToJDE(iDB2Command db2Command, FSTINV inv)
        {

            
            st.insertLog(string.Format("Inserting {0} to FSTINV table.", inv.Name),"Info", inv.SIID.ToString(),LogId);

            string tableName = inv.GetType().Name;

            if (inv.Items.Length > 0)
            {
                for (int x = 0; x < inv.Items.Length; x++)
                {
                    //10.12.16 JC: Check whether this is a recurring service (parameter send invoice and a invoice item)
                   // inv.Items[x].IsRecurringService = serviceTrade.IsRecurringService(inv, inv.Items[x]);

                   // st.insertLog(string.Format("New vs Recurring Check result: {0}, {1}, {2}", inv.SIID, inv.Items[x].LibItem.Name, inv.Items[x].IsRecurringService), "Info", "NA", LogId);

                    using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction())
                    {
                        db2Command.Transaction = db2Transaction;

                        db2Command.CommandText = string.Format("INSERT INTO {0} (SIID, SIAN8, SILAN8, SISSTS, SIINV, SITECH, SILOC, SITYPE, SITOTL, SIPO, SIITEM, SIITYP, SIDESC, SIQTY, SIPRIC, SICRDT, SIJOB, SISLSM, SISLS2, SISLS3, SIDFLG, SIUSER1) VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20, @p21, @p22) WITH NONE",
                                                          tableName);
                        
                        //Recurring service
                       // db2Command.CommandText = db2Command.CommandText.Replace("@p22", string.Format("'{0}'", inv.Items[x].IsRecurringService ? "Yes" : "No"));
                        db2Command.CommandText = db2Command.CommandText.Replace("@p22", string.Format("'{0}'", "NA"));  

                        //Flag to Determine Service Type
                        db2Command.CommandText = db2Command.CommandText.Replace("@p21", string.Format("'{0}'", inv.FPMARActive ? "FPMAR" : ""));                       
                        //Salesman 3
                        db2Command.CommandText = db2Command.CommandText.Replace("@p20", string.Format("'{0}'", (inv.Technician != null && inv.Technician.Length > 1) ? inv.Technician[1].SITECH : null));                       
                        //Salesman 2
                        db2Command.CommandText = db2Command.CommandText.Replace("@p19", string.Format("'{0}'", (inv.Tags != null && inv.Tags.Count > 1) ? inv.Tags[1] : null));
                        //Salesman 1
                        db2Command.CommandText = db2Command.CommandText.Replace("@p18", string.Format("'{0}'", (inv.Tags != null && inv.Tags.Count > 0) ? inv.Tags[0] : null));
                        //Service Trade Job ID
                        db2Command.CommandText = db2Command.CommandText.Replace("@p17", string.Format("'{0}'", inv.Job.JobId));
                       //Created Date
                        db2Command.CommandText = db2Command.CommandText.Replace("@p16", string.Format("'{0}'", new iDB2TimeStamp(inv.CreatedDateTime.ToString("MM/dd/yyyy h:mm:ss.ffffff")).ToNativeFormat()));
                        //Item Price
                        db2Command.CommandText = db2Command.CommandText.Replace("@p15", string.Format("'{0}'", inv.Items[x].Price));
                        //Item Quanity
                        db2Command.CommandText = db2Command.CommandText.Replace("@p14", string.Format("'{0}'", Math.Round(inv.Items[x].Quantity, 2))); //6.23.16 JC - Hiller wants to limit the item qty to two decimal places.
                        //Service Trade Item Description
                        db2Command.CommandText = db2Command.CommandText.Replace("@p13", string.Format("'{0}'", inv.Items[x].Description.Length <= 50 ? (inv.Items[x].Description).Replace("'", "''") : (inv.Items[x].Description.Substring(0, 50)).Replace("'", "''")));
                        //Service Trade Item Type
                        db2Command.CommandText = db2Command.CommandText.Replace("@p12", string.Format("'{0}'", inv.Items[x].LibItem.Type));
                        //ITEM ID
                        db2Command.CommandText = db2Command.CommandText.Replace("@p11", string.Format("'{0}'", inv.Items[x].LibItem.Code));
                        //Customer PO
                        db2Command.CommandText = db2Command.CommandText.Replace("@p10", string.Format("'{0}'", string.IsNullOrEmpty(inv.CustomerPo) ? string.Empty : inv.CustomerPo.Replace("'", string.Empty)));
                        //Service Trade ID
                        db2Command.CommandText = db2Command.CommandText.Replace("@p1", string.Format("'{0}'", inv.SIID));
                        //JDE Address Book number for the Company
                        db2Command.CommandText = db2Command.CommandText.Replace("@p2", string.Format("'{0}'", inv.Customer.External.JdeId));
                        //JDE Address Book number for the Location
                        db2Command.CommandText = db2Command.CommandText.Replace("@p3", string.Format("'{0}'", inv.Location.External.JdeId));
                        //Service Trade invoice Status
                        db2Command.CommandText = db2Command.CommandText.Replace("@p4", string.Format("'{0}'", inv.Status));
                        //Service Trade Invoice number
                        db2Command.CommandText = db2Command.CommandText.Replace("@p5", string.Format("'{0}'", inv.InvoiceNumber));
                        //Service Trade Technician
                        db2Command.CommandText = db2Command.CommandText.Replace("@p6", string.Format("'{0}'", (inv.Technician != null && inv.Technician.Length > 0) ? inv.Technician[0].SITECH : null));
                        //Service Trade Location (e.g. FT. Walton 123, Pensacola 122)
                        db2Command.CommandText = db2Command.CommandText.Replace("@p7", string.Format("'{0}'", inv.ServicingOffice != null ? inv.ServicingOffice.OfficeId : null));
                        //Service Trade Invoice Type
                        db2Command.CommandText = db2Command.CommandText.Replace("@p8", string.Format("'{0}'", inv.Type));
                        //Inovice Total Amount
                        db2Command.CommandText = db2Command.CommandText.Replace("@p9", string.Format("'{0}'", inv.TotalPrice));

                      //  st.insertLog(db2Command.CommandText, "FSTINV: Insert Query multiple items", "NA", LogId);
                        var recordsAffected = db2Command.ExecuteNonQuery();

                        db2Command.Transaction.Commit();

                        st.insertLog(string.Format("Rows affected: {0}", recordsAffected), "Info", "NA", LogId);
                    }

                }
            }
            else
            {
                using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction())
                {
                    db2Command.Transaction = db2Transaction;

                    db2Command.CommandText = string.Format("INSERT INTO {0} (SIID, SIAN8, SISSTS, SIINV, SITECH, SILOC, SITOTL, SIPO, SICRDT, SIJOB, SISLSM, SISLS2, SISLS3, SIDFLG) VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14) WITH NONE",
                                                      tableName);

                    db2Command.CommandText = db2Command.CommandText.Replace("@p14", string.Format("'{0}'", inv.FPMARActive ? "FPMAR" : ""));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p13", string.Format("'{0}'", (inv.Technician != null && inv.Technician.Length > 1) ? inv.Technician[1].SITECH : null));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p12", string.Format("'{0}'", (inv.Tags != null && inv.Tags.Count > 1) ? inv.Tags[1] : null));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p11", string.Format("'{0}'", (inv.Tags != null && inv.Tags.Count > 0) ? inv.Tags[0] : null));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p10", string.Format("'{0}'", inv.Job.JobId));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p1", string.Format("'{0}'", inv.SIID));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p2", string.Format("'{0}'", inv.Customer.CompanyId));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p3", string.Format("'{0}'", inv.Status));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p4", string.Format("'{0}'", inv.InvoiceNumber));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p5", string.Format("'{0}'", (inv.Technician != null && inv.Technician.Length > 0) ? inv.Technician[0].SITECH : null));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p6", string.Format("'{0}'", inv.ServicingOffice != null ? inv.ServicingOffice.OfficeId : null));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p7", string.Format("'{0}'", inv.TotalPrice));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p8", string.Format("'{0}'", string.IsNullOrEmpty(inv.CustomerPo) ? string.Empty : inv.CustomerPo.Replace("'", string.Empty)));
                    db2Command.CommandText = db2Command.CommandText.Replace("@p9", string.Format("'{0}'", new iDB2TimeStamp(inv.CreatedDateTime.ToString("MM/dd/yyyy h:mm:ss.ffffff")).ToNativeFormat()));



                   // st.insertLog(db2Command.CommandText, "FSTINV: Insert Query no items", "NA", LogId);
                    var recordsAffected = db2Command.ExecuteNonQuery();

                    db2Command.Transaction.Commit();

                    st.insertLog(string.Format("Rows affected: {0}", recordsAffected), "Info", "NA", LogId);
                }
            }

            //Onces inserted, change the status to processed for updating ServiceTrade
            inv.Status = "processed";

        }

        //This Function inserts comments to the FSTINVC Table
        private void InsertComments(iDB2Command db2Command, FSTINV inv)
        {
            st.insertLog(string.Format("Inserting notes for {0} to FSTINVC table.", inv.SIID), "Info", inv.SIID.ToString(), HillerServiceDataMigrator.LogId);

            string tableName = "FSTINVC";

            using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction())
            {
                db2Command.Transaction = db2Transaction;

                db2Command.CommandText = string.Format("INSERT INTO {0} (SCID, SCCMTS, SCCRDT) VALUES(@p1, @p2, @p3) WITH NONE",
                                                  tableName);
                db2Command.CommandText = db2Command.CommandText.Replace("@p1", string.Format("'{0}'", inv.SIID));
                db2Command.CommandText = db2Command.CommandText.Replace("@p2", string.Format("'{0}'", inv.Notes.Replace("'", "''")));
                db2Command.CommandText = db2Command.CommandText.Replace("@p3", string.Format("'{0}'", new iDB2TimeStamp(inv.CreatedDateTime.ToString("MM/dd/yyyy h:mm:ss.ffffff")).ToNativeFormat()));

              //  st.insertLog(db2Command.CommandText, "FSTINVC: Insert Query", "NA",LogId);
               
                var recordsAffected = db2Command.ExecuteNonQuery();
                
                db2Command.Transaction.Commit();

                st.insertLog(string.Format("Rows affected: {0}", recordsAffected), "Info", "NA", LogId);
              
            }
        }

        
        //Update Invoice in service Trade to Done
        private void SendInvoiceUpdates(iDB2Command db2Command)
        {

            st.insertLog("Sending invoice update to Service Trade.", "info", "NA", LogId);

            Dictionary<string, Invoice> jdeInvList = new Dictionary<string, Invoice>();

            using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction())
            {
                db2Command.Transaction = db2Transaction;

                db2Command.CommandText = string.Format("SELECT DISTINCT SIID, SIAN8, SIJOB, SIDOCO, SIDCTO, SICRDT FROM FSTINV WHERE SISTAT = 'P'");
                
                iDB2DataReader reader = db2Command.ExecuteReader();
              
                while (reader.Read())
                {
                    Invoice temp = new Invoice();
                    temp.SIID = ((string)reader["SIID"]).Trim();                    
                    temp.type = "invoice";
                    //always set this to processed status to avoid breaking the status in ST
                    temp.status = "processed"; 
                    temp.jobId = Int32.Parse((string)reader["SIJOB"]);
                    //Change Invoice Number (Concat JDE Document Number and Document Type with -)
                    temp.invoiceNumber = string.Format("{0}-{1}", reader["SIDOCO"], reader["SIDCTO"]);
                    temp.transactionDate = (Int32)((DateTime)reader["SICRDT"] - unixBaseTime).TotalSeconds;
                    //temp.assignedUserId= Int32.Parse((string)reader["SITECH"]);                    

                    //09/18/2015 - This limits the invoices being sent for update in ST.
                    //if (!jdeInvList.ContainsKey((string)reader["SIAN8"]))
                    //{
                    //    jdeInvList.Add((string)reader["SIAN8"], temp);
                    //    sent++;
                    //}

                    if (reader["SIAN8"] != null)
                    {
                        //12/19/16 JC: This will avoid duplicate records.
                        if (!jdeInvList.ContainsKey(temp.SIID))
                        {
                            jdeInvList.Add((string)temp.SIID, temp);
                        }
                        
                    }
                }

                reader.Close();
            }

            db2Command.Transaction.Dispose();

            if (jdeInvList.Count > 0)
            {
                st.insertLog(string.Format("Found {0} invoices for update", jdeInvList.Count), "Info", "NA", LogId);
           
                foreach (var jde in jdeInvList)
                {
                    

                    //var status = jde.Value.status;

                    //Query the single invoice from the service Trade
                    var invoice = serviceTrade.GetInvoice(jde.Key);

                    //Mark the invoice as done in FSTINV, if the status of the invoice is void in Service Trade
                    if (invoice.Status == "void" || invoice.Status != "pending_accounting")
                    {
                        st.insertLog(string.Format("The status of invoice number {0} is not <pending_accounting> in service Trade.", jde.Key), "Error", jde.Key.ToString(), LogId);
                        SetInvoiceToDone(db2Command, jde.Value);
                     
                    }
                    else
                    {
                        if (serviceTrade.UpdateInvoice(jde.Value))
                    {

                        st.insertLog(string.Format("The status of invoice number {0} is set to processed in Service Trade.", jde.Key), "Info", jde.Key.ToString(), LogId);
                        SetInvoiceToDone(db2Command, jde.Value);
                    }
                    }

                    
                }
            }
            else 
            {
                st.insertLog("No invoice update to be sent.", "Info", "NA", LogId);
             }
        }

        //Mark the Status to Done "D" on FSTINV
        private void SetInvoiceToDone(iDB2Command db2Command, Invoice inv)
        {
            st.insertLog("Set " + inv.SIID + " invoice to done", "info", inv.SIID.ToString(), LogId);
            

            using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction(IsolationLevel.Chaos))
            {
                db2Command.Transaction = db2Transaction;

                db2Command.CommandText = string.Format("UPDATE FSTINV SET SISTAT = @status WHERE SIID = {0}", inv.SIID);
                db2Command.DeriveParameters();
                db2Command.Parameters["@status"].Value = 'D';

              //  st.insertLog(db2Command.CommandText, "FSTINV Update Query", "NA", LogId);
                
                var recordsAffected = db2Command.ExecuteNonQuery();

                db2Command.Transaction.Commit();
                db2Command.Transaction.Dispose();

                st.insertLog(string.Format("Rows affected: {0}", recordsAffected), "Info", "NA", LogId);
              
            }

            
        }
        #endregion

        public void StopMigration()
        {
            forceStop = true;
            st.insertLog("Stopping Migration", "Info", "NA", LogId);
               
        }


    }
}
