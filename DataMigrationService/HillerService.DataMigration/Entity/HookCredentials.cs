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
    
    public partial class HookCredentials
    {
        public int id { get; set; }
        public string ServiceTradeURI { get; set; }
        public string ServiceTradeUserName { get; set; }
        public string ServiceTradePassword { get; set; }
        public string AS400ConnectionString { get; set; }
        public string ServiceTradeURITest { get; set; }
        public string ServiceTradeUserNameTest { get; set; }
        public string ServiceTradePasswordTest { get; set; }
        public string AS400ConnectionStringTest { get; set; }
        public Nullable<bool> runProductionMode { get; set; }
    }
}