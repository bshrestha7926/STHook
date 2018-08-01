using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class LocationDataContract
    {
        [DataMember(Name = "data")]
        public FSTLOCN FSTLOCN { get; set; }
    }

    [DataContract]
    public class FSTLOCN
    {
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        [DataMember(Name = "id")]
        public int LocationId { get; set; }
        [DataMember(Name = "name")]
        public string NAME { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "generalManager")]
        public string GeneralManager { get; set; }
        [DataMember(Name = "primaryContact")]
        public Contact PrimaryContact { get; set; }
        [DataMember(Name = "updated")]
        public int Updated { get; set; }
        [DataMember(Name = "address")]
        public Address Address { get; set; }
        [DataMember(Name = "company")]
        public FSTCOMP Company { get; set; }       
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "offices")]
        public Office[] Offices { get; set; }
        [DataMember(Name = "externalIds")]
        public ExternalId External { get; set; }
    }
}
