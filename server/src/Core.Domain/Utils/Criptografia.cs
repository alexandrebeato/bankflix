using System;
using System.Security.Cryptography;
using System.Text;

namespace Core.Domain.Utils
{
    public static class Criptografia
    {
        public static string CriptografarComMD5(string valor)
        {
            using (var md5Hash = MD5.Create())
            {
                string hash = ObterHashMd5(md5Hash, valor);
                return hash;
            }
        }

        private static string ObterHashMd5(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string CriptografarComBase64(string valor)
        {
            var valorCriptografado = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(valor))
                {
                    var bytes = Encoding.UTF8.GetBytes(valor);
                    valorCriptografado = Convert.ToBase64String(bytes);
                }
            }
            catch { }

            return valorCriptografado;
        }

        public static string DescriptografarComBase64(string valor)
        {
            var valorDescriptografado = string.Empty;

            try
            {
                var bytes = Convert.FromBase64String(valor);
                valorDescriptografado = Encoding.UTF8.GetString(bytes);
            }
            catch { }

            return valorDescriptografado;
        }
    }
}
