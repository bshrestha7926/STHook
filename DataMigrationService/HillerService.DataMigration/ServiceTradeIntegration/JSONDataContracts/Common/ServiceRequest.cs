using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class ServiceRequestsDataContractMultiple
    {
        [DataMember(Name = "data")]
        public ServiceRequestsDataContract ServiceRequestsList { get; set; }
    }

    [DataContract]
    public class ServiceRequestsDataContract
    { 
        [DataMember(Name = "servicerequests")]
        public List<ServiceRequest> ServiceRequests { get; set; }
    }


    //JC: This is an old class but may still be being used somewhere
    [DataContract]
    public class ServiceRequests
    {
        private int timestamp1 = 0;
        private int timestamp2 = 0;

        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        [DataMember(Name = "id")]
        public int? ServiceRequestsId { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "serviceLine")]
        public string ServiceLine { get; set; }
        [DataMember(Name = "serviceLineId")]
        public int? ServiceLineId { get; set; }
        [DataMember(Name = "windowStart")]
        public int WindowStart { get { return timestamp1; } set { timestamp1 = value; } }
        [IgnoreDataMember]
        public DateTime WindowStartDateTime { get { DateTime baseStart = new DateTime(1970, 1, 1, 1, 1, 1, 1); return baseStart.AddSeconds(timestamp1); } }
        [DataMember(Name = "windowEnd")]
        public int WindowEnd { get { return timestamp2; } set { timestamp2 = value; } }
        [IgnoreDataMember]
        public DateTime WindowEndDateTime { get { DateTime baseStart = new DateTime(1970, 1, 1, 1, 1, 1, 1); return baseStart.AddSeconds(timestamp2); } }
        [DataMember(Name = "estimatedPrice")]
        public decimal? EstimatedPrice { get; set; }
        [DataMember(Name = "duration")]
        public int? Duration { get; set; }       
    }

    [DataContract]
    public class ServiceRequest
    {
        private int timestamp1 = 0;
        private int timestamp2 = 0;

        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "serviceLine")]
        public List<ServiceLine> ServiceLine { get; set; }
        [DataMember(Name = "serviceRecurrence")]
        public List<ServiceRecurrence> ServiceRecurrence { get; set; }

        [DataMember(Name = "windowStart")]
        public int WindowStart { get { return timestamp1; } set { timestamp1 = value; } }
        [IgnoreDataMember]
        public DateTime WindowStartDateTime { get { DateTime baseStart = new DateTime(1970, 1, 1, 1, 1, 1, 1); return baseStart.AddSeconds(timestamp1); } }
        [DataMember(Name = "windowEnd")]
        public int WindowEnd { get { return timestamp2; } set { timestamp2 = value; } }
        [IgnoreDataMember]
        public DateTime WindowEndDateTime { get { DateTime baseStart = new DateTime(1970, 1, 1, 1, 1, 1, 1); return baseStart.AddSeconds(timestamp2); } }

    }
    
}
