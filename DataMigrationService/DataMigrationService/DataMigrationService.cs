using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Management;
using DataMigrationService.Utilities.Interfaces;
using DataMigrationService.Utilities.EventHandlers;
using HillerService.DataMigration.ServiceTradeIntegration;

namespace DataMigration
{
    partial class DataMigrationService : ServiceBase
    {
        private List<Thread> dataMigrationThreads;
        private IDataMigrator dataMigrator;
      

        private int PollingInterval { get { return Convert.ToInt32(ConfigurationManager.AppSettings["PollingInterval"]); } }
        

        public DataMigrationService()
        {
            InitializeComponent();
            InitializeService();
        }

        private void InitializeService()
        {
            dataMigrationThreads = new List<Thread>();

            dataMigrator = new HillerServiceDataMigrator();            
        }     

        private void StartDataMigrationThread(IDataMigrator dataMigrator)
        {
            Thread activeThread = null;

            // determine if we have an active thread for this data migrator
            activeThread = dataMigrationThreads.FirstOrDefault(thread => thread.Name.Equals(dataMigrator.Name));

            if(activeThread != null &&
                !activeThread.IsAlive)
            {
                dataMigrationThreads.Remove(activeThread);
                activeThread = null;
            }

            if (activeThread == null)
            {
                if (dataMigrator is IMigratorEvents)
                {
                    (dataMigrator as IMigratorEvents).DataMigrationStop += new MigrationStop(DataMigrationService_DataMigrationStop);                    
                }

                activeThread = new Thread(new ThreadStart(dataMigrator.PerformMigration)) { Name = dataMigrator.Name };
                dataMigrationThreads.Add(activeThread);
                
               // log.Debug(string.Format("Starting thread for {0}", dataMigrator.Name));
                activeThread.Start();

            }
        }

        protected void DataMigrationService_DataMigrationStop(object sender, MigrationEventArgs e)
        {
            if (e.status)
            {
                //log.Debug("Stopping service");
                StopDataMigrationThread(sender as IDataMigrator);               
            }
        }

        protected override void OnStart(string[] args)
        {
          //  log.Info("Data migration service starting");

          //  log.Debug("Begin Starting Data Migration Threads");

            
            StartDataMigrationThread(dataMigrator);
            

           // log.Debug("End Starting Data Migration Threads");
        }

        protected override void OnStop()
        {
           // log.Info("Data migration service stopping");

          //  log.Info("Stopping active data migration threads");
            
            //
            //StopDataMigrationThread(dataMigrator);

            base.OnStop();
        }

        private void StopDataMigrationThread(IDataMigrator dataMigrator)
        {
            //log.Debug("Stopping data migration thread: " + dataMigrator.Name);

            dataMigrator.StopMigration();

            Thread activeThread = dataMigrationThreads.FirstOrDefault(thread => thread.Name.Equals(dataMigrator.Name));
            if (activeThread != null)
            {                
                try
                {
                    activeThread.Abort();
                }
                catch (ThreadAbortException ex)
                {
                    //log.Debug(string.Empty, ex);
                    dataMigrationThreads.Remove(activeThread);
                    activeThread = null;
                    //Stop the service
                    this.Stop();
                }
                                
            }
        }
    }
}
