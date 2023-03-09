#if DEBUG    //If you are thinking about removing this line, you are probably about to make a major mistake.
             //SHA-512 is considered secure against collision attacks, but not against length extension.
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium CryptoHash implementation of SHA512.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    [SecurityConcern(description = "This cipher provides no protection against length extension attacks.", conditionsDescription = "Where length extension safety is needed.")]
    [SecurityCritical]
    public class SodiumSHA512 : IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.CryptoHash.Sha512(input);
        }
        public string primitiveName => "SHA-512";
        public string primitiveVariation => null;
        public string implementationName => "LibSodium";
        public string primitiveID => "SHA-512";
    }
}
#endif