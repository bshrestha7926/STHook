using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class Address
    {
        //JDE Address Line 1/St street
        [DataMember(Name = "street")]
        public string Street { get; set; }
        //JDE City/ST city
        [DataMember(Name = "city")]
        public string City { get; set; }
        //JDE State Code/ST state
        [DataMember(Name = "state")]
        public string State { get; set; }
        //JDE Zip/ST postalCode
        [DataMember(Name = "postalCode")]
        public string PostalCode { get; set; }
    }
}
