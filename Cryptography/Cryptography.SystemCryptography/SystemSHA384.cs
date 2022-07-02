using System.Security.Cryptography;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of SHA384.
    /// SHA-384 provides 192 bits of security against length extension attacks.
    /// </summary>
    public class SystemSHA384 : IHash
    {
        SHA384Managed sha = new SHA384Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-384";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
        public string primitiveID => "SHA-384";
    }
}