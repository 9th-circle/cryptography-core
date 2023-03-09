#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
            //SHA-256 is considered secure against collision attacks, but not against length extension.
using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium CryptoHash implementation of SHA256.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    [Audit.Interfaces.Annotations.SecurityConcern(description = "This cipher provides no protection against length extension attacks.", conditions = "Where length extension safety is needed.")]
    public class SodiumSHA256 : IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.CryptoHash.Sha256(input);
        }
        public string primitiveName => "SHA-256";
        public string primitiveVariation => null;
        public string implementationName => "LibSodium";
        public string primitiveID => "SHA-256";
    }
}
#endif