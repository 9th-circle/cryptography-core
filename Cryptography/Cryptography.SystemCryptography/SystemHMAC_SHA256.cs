using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemHMAC_SHA256 : Interfaces.IMAC
    {
        HMACSHA256 hmac = new HMACSHA256();
        public byte[] generate(byte[] input, byte[] key)
        {
            hmac.Key = key;
            return hmac.ComputeHash(input);
        }
        public string primitiveName => "HMAC-SHA-256";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
    }
}