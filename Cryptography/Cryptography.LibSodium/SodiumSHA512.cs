namespace Cryptography.LibSodium
{
    public class SodiumSHA512 : Interfaces.IHash
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