//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HillerService.DataMigration.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMTPSettings
    {
        public int id { get; set; }
        public string SMTPHost { get; set; }
        public string SMTPPort { get; set; }
        public Nullable<bool> SMTPEnableSSL { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPNotificationEmail { get; set; }
    }
}
