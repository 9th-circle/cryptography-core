using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemSHA256 : Interfaces.IHash
    {
        SHA256Managed sha = new SHA256Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-256";
        public string primitiveVariation => null;
        public string implementationName => "System.Cryptography";
    }
}