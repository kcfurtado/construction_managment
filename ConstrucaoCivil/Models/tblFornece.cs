//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblFornece
    {
        public int id_fornece { get; set; }
        public int id_fornecedor { get; set; }
        public int id_equip { get; set; }
        public string modo { get; set; }
        public Nullable<int> quantidade { get; set; }
        public Nullable<int> custo { get; set; }
        public System.DateTime data_inicio { get; set; }
        public System.DateTime data_fim { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
    
        public virtual tblEquipamento tblEquipamento { get; set; }
        public virtual tblFornecedor tblFornecedor { get; set; }
    }
}