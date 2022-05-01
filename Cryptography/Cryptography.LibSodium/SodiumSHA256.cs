namespace Cryptography.LibSodium
{
    class SodiumSHA256 : Interfaces.IHash
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