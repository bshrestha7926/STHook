using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class ServiceRecurrenceDataContract
    { 
        [DataMember(Name = "data")]
        public ServiceRecurrence ServiceRecurrence { get; set; }
    }

    [DataContract]
    public class ServiceRecurrence
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "frequency")]
        public string Frequency { get; set; }
        [DataMember(Name = "interval")]
        public int Interval { get; set; }
        [DataMember(Name = "repeatWeekday")]
        public bool RepeatWeekday { get; set; }
    }
}
