﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StaffMgtSysDbEntities : DbContext
    {
        public StaffMgtSysDbEntities()
            : base("name=StaffMgtSysDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<StaffTb> StaffTbs { get; set; }
        public virtual DbSet<DepartmentTb> DepartmentTbs { get; set; }
        public virtual DbSet<ResourcesTb> ResourcesTbs { get; set; }
        public virtual DbSet<RolesTb> RolesTbs { get; set; }
    }
}