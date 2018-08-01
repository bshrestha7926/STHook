using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMigrationService.Utilities.EventHandlers
{
    public delegate void MigrationStop(object sender, MigrationEventArgs e);

    public class MigrationEventArgs : EventArgs
    {
        public readonly bool status;
        public MigrationEventArgs(bool stop)
        {
            status = stop;
        }
    }
}
