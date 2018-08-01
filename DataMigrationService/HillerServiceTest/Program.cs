using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HillerService.DataMigration.ServiceTradeIntegration;

namespace STHook
{
    class Program
    {
        static void Main(string[] args)
        {

            //run migration process
            HillerServiceDataMigrator hs = new HillerServiceDataMigrator();

            hs.PerformMigration();


            //Console.ReadLine();
        }

        static void hs_DataMigrationStop(bool stop)
        {
            if (stop)
                Console.WriteLine("Ok to close");
        }

        static void StopMe(bool stop)
        {
            if (stop)
                Console.WriteLine("Ok to close");
        }
    }
}
