using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMigrationService.Utilities.Interfaces
{
    public interface IDataMigrator
    {
        void PerformMigration();

        void StopMigration();

        string Name { get; set; }
    }
}
