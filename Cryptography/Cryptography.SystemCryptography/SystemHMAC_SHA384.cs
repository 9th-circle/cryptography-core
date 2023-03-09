using System.Security.Cryptography;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography Message Authentication Code based on SHA384.
    /// </summary>
    [SecurityCritical]
    public class SystemHMAC_SHA384 : IMAC
    {
        HMACSHA384 hmac = new HMACSHA384();
        public byte[] generate(byte[] input, byte[] key)
        {
            hmac.Key = key;
            return hmac.ComputeHash(input);
        }
        public string primitiveName => "HMAC-SHA-384";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
        public string primitiveID => "HMAC-SHA-384";
    }
}