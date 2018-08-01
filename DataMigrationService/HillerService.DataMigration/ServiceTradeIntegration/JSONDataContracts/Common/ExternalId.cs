using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class ExternalId
    {
        [DataMember(Name = "jde")]
        public string JdeId { get; set; }
    }
}
