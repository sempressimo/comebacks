﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Comeback_Service
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComebackEntities : DbContext
    {
        public ComebackEntities()
            : base("name=ComebackEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ComebackReason> ComebackReasons { get; set; }
        public virtual DbSet<Comeback> Comebacks { get; set; }
        public virtual DbSet<ComebackSubReason> ComebackSubReasons { get; set; }
    }
}
