using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium GenericHash implementation of BLAKE2b.
    /// </summary>
    public class SodiumGenericMAC : IMAC
    {
        public byte[] generate(byte[] input, byte[] key)
        {
            return Sodium.GenericHash.Hash(input, key, input.Length);
        }

        public string primitiveName => "BLAKE2b";
        public string primitiveVariation => "CryptoGeneticHash";
        public string implementationName => "LibSodium";
        public string primitiveID => "BLAKE2b";
    }
}