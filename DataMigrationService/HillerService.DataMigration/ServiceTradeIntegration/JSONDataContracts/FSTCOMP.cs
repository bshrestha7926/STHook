using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    /*
     * Use for serializing Company JSON object coming from service trade
     */
    [DataContract]
    public class CompanyContract
    {
        [DataMember(Name = "data")]
        public FSTCOMP IFSTCOMP { get; set; }
    }

    [DataContract]
    public class FSTCOMP
    {
        [DataMember(Name = "uri")]
        public string Uri { get; set; }

        [DataMember(Name = "id")]
        public int CompanyId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "customer")]
        public bool Customer { get; set; }

        [DataMember(Name = "vendor")]
        public bool Vendor { get; set; }

        [DataMember (Name = "primeContractor")]
        public bool PrimeContractor { get; set; }

        [DataMember(Name = "shareId")]
        public int? ShareId { get; set; }

        [DataMember(Name = "address")]
        public Address Address { get; set; }

        [DataMember(Name = "serviceLinesProvided")]
        public ServiceLine[] ServiceLinesProvide { get; set; }

        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "externalIds")]
        public ExternalId External { get; set; }

    }
}
