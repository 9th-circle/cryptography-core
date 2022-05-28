using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium CryptoHash implementation of SHA256.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    public class SodiumSHA256 : IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.CryptoHash.Sha256(input);
        }
        public string primitiveName => "SHA-256";
        public string primitiveVariation => null;
        public string implementationName => "LibSodium";
    }
}