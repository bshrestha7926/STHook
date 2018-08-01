using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class JobDataContract
    {
        [DataMember(Name = "data")]
        public Job Job { get; set; }
    }

    [DataContract]
    public class Job
    {
        [DataMember(Name = "id")]
        public int JobId { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "number")]
        public int Number { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        [DataMember(Name = "serviceRequests")]
        public ServiceRequests[] ServiceRequests { get; set; }
    }

    
}
