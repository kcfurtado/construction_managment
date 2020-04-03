using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Text;

namespace ConstrucaoCivil.Helpers
{
    public class Encrypt
    {
        public static string GetMD5Has(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] b = Encoding.UTF8.GetBytes(password);
                b = md5.ComputeHash(b);
                StringBuilder sb = new StringBuilder();

                foreach (byte x in b)
                    sb.Append(x.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}