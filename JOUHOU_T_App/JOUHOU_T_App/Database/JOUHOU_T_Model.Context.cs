﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JOUHOU_T_App.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JOUHOU_TEntities : DbContext
    {
        public JOUHOU_TEntities()
            : base("name=JOUHOU_TEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GROUP_T> GROUP_T { get; set; }
        public virtual DbSet<JOUHOU_T> JOUHOU_T { get; set; }
    }
}