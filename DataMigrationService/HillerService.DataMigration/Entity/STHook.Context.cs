﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class STHookEntities : DbContext
    {
        public STHookEntities()
            : base("name=STHookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DailyLog> DailyLog { get; set; }
        public virtual DbSet<STHookLog> STHookLog { get; set; }
        public virtual DbSet<SMTPSettings> SMTPSettings { get; set; }
        public virtual DbSet<HookCredentials> HookCredentials { get; set; }
    }
}
