﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstrucaoCivil.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConstrucaoCivEntities : DbContext
    {
        public ConstrucaoCivEntities()
            : base("name=ConstrucaoCivEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAbastece> tblAbastece { get; set; }
        public virtual DbSet<tblCliente> tblCliente { get; set; }
        public virtual DbSet<tblConsome> tblConsome { get; set; }
        public virtual DbSet<tblEquipamento> tblEquipamento { get; set; }
        public virtual DbSet<tblFornece> tblFornece { get; set; }
        public virtual DbSet<tblFornecedor> tblFornecedor { get; set; }
        public virtual DbSet<tblFuncionario> tblFuncionario { get; set; }
        public virtual DbSet<tblMaterial> tblMaterial { get; set; }
        public virtual DbSet<tblObra> tblObra { get; set; }
        public virtual DbSet<tblPagamento> tblPagamento { get; set; }
        public virtual DbSet<tblRequer> tblRequer { get; set; }
        public virtual DbSet<tblTrabalha> tblTrabalha { get; set; }
    }
}
