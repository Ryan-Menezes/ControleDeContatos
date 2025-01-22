using System.Security.Cryptography;
using System.Text;

namespace ControleDeContatos.Helpers
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encode = new ASCIIEncoding();
            var bytes = encode.GetBytes(valor);

            bytes = hash.ComputeHash(bytes);

            var strHexa = new StringBuilder();

            foreach (var item in bytes)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
