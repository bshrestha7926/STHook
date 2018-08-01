using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    //JSON Entry
    [DataContract]
    public class InvoiceDataContractMultiple
    {
        [DataMember(Name = "data")]
        public InvoicesDataContract Invoices { get; set; }
        
    }

    //For single invoice 
    [DataContract]
    public class InvoiceDataContract
    {
        [DataMember(Name = "data")]
        public FSTINV IFSTINV { get; set; }

    }

    //For multiple invoices
    [DataContract]
    public class InvoicesDataContract
    {
        [DataMember(Name = "totalPages")]
        public int TotalPages { get; set; }
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "invoices")]
        public List<FSTINV> InvoiceList { get; set; }
    }

    [DataContract]
    public class FSTINV
    {
        private int timestamp = 0;
        private CommentsList comments;

        [DataMember(Name = "id")]
        public string SIID { get; set; }
        [DataMember (Name = "uri")]
        public string Uri { get; set; }      
        [DataMember(Name = "name")]
        public string Name { get; set; }        
        [DataMember(Name = "type")]
        public string Type { get; set; }        
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "invoiceNumber")]
        public string InvoiceNumber { get; set; }        
        [DataMember(Name = "totalPrice")]
        public double TotalPrice { get; set; }
        [DataMember(Name = "location")]
        public FSTLOCN Location { get; set; }
        [IgnoreDataMember]
        public Office ServicingOffice { get; set; }
        [DataMember(Name = "job")]
        public Job Job { get; set; }
        //This will come from appointment as tech
        public User[] Technician { get; set; }
        [DataMember(Name = "customer")]
        public FSTCOMP Customer { get; set; }
        [DataMember(Name = "customerPo")]
        public string CustomerPo { get; set; }
        [DataMember(Name = "vendor")]
        public FSTCOMP Vendor { get; set; }
        [DataMember(Name = "items")]
        public Item[] Items { get; set; }
        [DataMember(Name = "notes")]
        public string Notes { get; set; }
        [IgnoreDataMember]
        public List<string> Tags { get; set; }
        [IgnoreDataMember]
        public CommentsList CommentsList
        {
            get { return comments; }
            set
            {
                foreach (Comment comment in value.Comments)
                {
                    comment.InvId = this.SIID;
                }

                this.comments = value;
            }
        }
        [IgnoreDataMember]
        public bool FPMARActive { get; set; }
        [DataMember(Name = "created")]
        public int Created { get { return timestamp; } set { timestamp = value; } }     
        [IgnoreDataMember]
        public DateTime CreatedDateTime { get { DateTime baseStart = new DateTime(1970, 1, 1, 1, 1, 1, 1); return baseStart.AddSeconds(timestamp); } }

    }
}
