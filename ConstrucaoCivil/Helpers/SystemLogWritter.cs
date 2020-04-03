using ConstrucaoCivil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ConstrucaoCivil.Helpers
{
    public class SystemLogWritter
    {
        public string path = @"c:\ConstruçãoCivil\Log\system-lo.txt";

        public void WriteLogg(string kind, string status, DateTime date)
        {
            StreamWriter writer;
            writer = new StreamWriter(path);
            string dados = "["+ kind +"] -->" + date +" -->" + status + " \n";
            writer.WriteLine("lOGIN SUCCESSO");
            writer.Close();
        }
    }
}