using Mayordomo.Transversal.Common.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace Mayordomo.Transversal.Common.Main
{
    public class EncryptService : IEncryptService
    {
        public string Encrypt(Guid rawData)
        {
            byte[] bytes = rawData.ToByteArray();
            return WebEncoders.Base64UrlEncode(bytes);
        }

        public Guid Decrypt(string cipherText)
        {
            byte[] bytes = WebEncoders.Base64UrlDecode(cipherText);
            return new Guid(bytes);
        }
    }
}
