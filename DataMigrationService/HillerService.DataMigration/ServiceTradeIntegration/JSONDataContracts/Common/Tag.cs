using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{

    [DataContract]
    public class TagDataContractMultiple
    {
        [DataMember(Name = "data")]
        public TagsDataContract Tags { get; set; }

    }

    [DataContract]
    public class TagDataContract
    {
        [DataMember(Name = "data")]
        public Tag Tag { get; set; }
    }


    //For multiple Tags
    [DataContract]
    public class TagsDataContract
    {
        [DataMember(Name = "totalPages")]
        public int TotalPages { get; set; }
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "tags")]
        public List<Tag> TagsList { get; set; }
    }

     [DataContract]
    public class Tag

    {
       [DataMember(Name = "id")]
        public int TagId { get; set; }
       [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }

}
