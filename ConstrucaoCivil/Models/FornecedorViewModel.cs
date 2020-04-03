using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstrucaoCivil.Models
{
    public class FornecedorViewModel
    {
        public int id_fornecedor   { get; set; }
        public string nif             { get; set; }
        public string nome         { get; set; }
        public string area         { get; set; }
        public string servico      { get; set; }
        public string cidade       { get; set; }
        public string local        { get; set; }
        public string email        { get; set; }
        public string telefone     { get; set; }
        public string conta_bancaria  { get; set; }
        public System.DateTime createdAt    { get; set; }
        public System.DateTime updatedAt    { get; set; }
    }
}