using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemSHA512 : Interfaces.IHash
    {
        SHA512Managed sha = new SHA512Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-512";
        public string primitiveVariation => null;
        public string implementationName => "System.Cryptography";
    }
}