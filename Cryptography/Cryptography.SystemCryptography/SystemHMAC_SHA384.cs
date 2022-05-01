using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemHMAC_SHA384 : Interfaces.IMAC
    {
        HMACSHA384 hmac = new HMACSHA384();
        public byte[] generate(byte[] input, byte[] key)
        {
            hmac.Key = key;
            return hmac.ComputeHash(input);
        }
        public string primitiveName => "HMAC-SHA-384";
        public string primitiveVariation => null;
        public string implementationName => "System.Cryptography";
    }
}