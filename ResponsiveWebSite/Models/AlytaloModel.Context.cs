﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResponsiveWebSite.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlytaloBaseDataEntities : DbContext
    {
        public AlytaloBaseDataEntities()
            : base("name=AlytaloBaseDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sauna> Sauna { get; set; }
        public virtual DbSet<Lampo> Lampo { get; set; }
        public virtual DbSet<Huone> Huone { get; set; }
        public virtual DbSet<Valo> Valo { get; set; }
    }
}
