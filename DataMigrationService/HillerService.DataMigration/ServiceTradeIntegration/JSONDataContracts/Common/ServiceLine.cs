using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class ServiceLineDataContract
    {
        [DataMember(Name = "data")]
        public ServiceLine ServiceLine { get; set; }
    }

    [DataContract]
    public class ServiceLine
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "trade")]
        public string Trade { get; set; }
        [DataMember(Name = "abbr")]
        public string Abbr { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
    }
}
