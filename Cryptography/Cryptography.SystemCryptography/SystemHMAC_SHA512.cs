using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemHMAC_SHA512 : Interfaces.IMAC
    {
        HMACSHA512 hmac = new HMACSHA512();
        public byte[] generate(byte[] input, byte[] key)
        {
            hmac.Key = key;
            return hmac.ComputeHash(input);
        }
        public string primitiveName => "HMAC-SHA-512";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
    }
}