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
    
    public partial class tblTrabalha
    {
        public int id_obra { get; set; }
        public int id_func { get; set; }
        public System.DateTime data { get; set; }
        public System.DateTime createdAt { get; set; }
    
        public virtual tblFuncionario tblFuncionario { get; set; }
        public virtual tblObra tblObra { get; set; }
    }
}