using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of SHA512.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    public class SystemSHA512 : Interfaces.IHash
    {
        SHA512Managed sha = new SHA512Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-512";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
    }
}