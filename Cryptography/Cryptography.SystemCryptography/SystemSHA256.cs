#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
            //SHA-256 is considered secure against collision attacks, but not against length extension.
using System.Security.Cryptography;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of SHA256.
    /// </summary>
    [Audit.Interfaces.Annotations.SecurityConcern(description = "This cipher provides no protection against length extension attacks.", conditions = "Where length extension safety is needed.")]
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
        public string primitiveID => "SHA-256";
    }
}
#endif