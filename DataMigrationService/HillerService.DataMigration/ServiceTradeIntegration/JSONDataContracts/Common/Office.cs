using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class Office
    {
        [DataMember(Name = "id")]
        public int? OfficeId { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "legacyId")]
        public string LegacyId { get; set; }
        [DataMember(Name = "phone")]
        public Address Address { get; set; }
        
    }
}
