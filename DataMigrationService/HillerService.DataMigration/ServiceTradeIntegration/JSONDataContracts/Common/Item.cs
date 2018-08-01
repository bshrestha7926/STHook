using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class Item
    {    
        [DataMember(Name = "id")]
        public int SIITEM { get; set; }
       
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        [DataMember(Name = "quantity")]
        public double Quantity { get; set; }
        
        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "libItem")]
        public LibItem LibItem { get; set; }

        [DataMember(Name = "serviceLine")]
        public ServiceLine ServiceLine { get; set; }

        //10.12.16 JC: Use this flag to determine whether an invoice item is a recurring service
        [IgnoreDataMember]
        public bool IsRecurringService { get; set; }

    }

    [DataContract]
    public class LibItem
    { 
        [DataMember(Name = "id")]
        public int LibItemId { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "code")]
        public string Code { get; set; }
    }
}
