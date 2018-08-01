using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class User
    {
        
        [DataMember(Name = "id")]
        public int? SITECH { get; set; }
       
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
