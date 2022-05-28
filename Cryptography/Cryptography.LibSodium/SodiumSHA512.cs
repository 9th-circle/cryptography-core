using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium CryptoHash implementation of SHA512.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    public class SodiumSHA512 : IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.CryptoHash.Sha512(input);
        }
        public string primitiveName => "SHA-512";
        public string primitiveVariation => null;
        public string implementationName => "LibSodium";
    }
}