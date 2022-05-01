namespace Cryptography.LibSodium
{
    public class SodiumGenericHash : Interfaces.IMAC
    {
        public byte[] generate(byte[] input, byte[] key)
        {
            return Sodium.GenericHash.Hash(input, key, input.Length);
        }

        public string primitiveName => "BLAKE2b";
        public string primitiveVariation => "CryptoGeneticHash";
        public string implementationName => "LibSodium";
    }
}