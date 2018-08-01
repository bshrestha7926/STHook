using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataMigrationService.Utilities.EventHandlers;

namespace DataMigrationService.Utilities.Interfaces
{
    public interface IMigratorEvents
    {
        event MigrationStop DataMigrationStop;
    }
}
