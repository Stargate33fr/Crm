using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Crm.Api.Infrastructure.Helpers
{
    public static class UtilitaireChiffrement
    {
        public static string ChiffrerChaine(this string chaine)
        {
            // On convertit en byte
            var chaineToHash = Encoding.Unicode.GetBytes(chaine);
            // Et on chiffre 
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(chaineToHash);
                // On convertit le Hash en hexa
                return hash.Aggregate("", (current, t) => current + $"{t:X2}");
            }
        }
    }
}
