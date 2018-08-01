using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class CommentDataContainer
    {
        [DataMember(Name = "data")]
        public CommentsList CommentsList { get; set; }
    }

    [DataContract]
    public class CommentsList
    {
        [DataMember(Name = "comments")]
        public List<Comment> Comments { get; set; }

    }

    [DataContract]
    public class Comment
    {
        private int timestamp = 0;

        [IgnoreDataMember]
        public string InvId { get; set; }
        [DataMember(Name = "content")]
        public string Content { get; set; }
        [DataMember(Name = "created")]
        public int Created { get { return timestamp; } set { timestamp = value; } }
        [IgnoreDataMember]
        public DateTime CreatedDateTime { get { DateTime baseStart = new DateTime(1970, 1, 1, 1, 1, 1, 1); return baseStart.AddSeconds(timestamp); } }
    }
}
