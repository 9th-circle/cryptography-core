using System.Security.Cryptography;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of SHA256.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    public class SystemSHA256 : IHash
    {
        SHA256Managed sha = new SHA256Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-256";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
    }
}