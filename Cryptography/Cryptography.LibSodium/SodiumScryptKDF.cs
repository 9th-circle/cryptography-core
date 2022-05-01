using Cryptography.Interfaces;

namespace Cryptography.LibSodium
{
    public class SodiumScryptKDF : IKDF
    {
        public byte[] generateSalt()
        {
            return Sodium.PasswordHash.ScryptGenerateSalt();
        }
        public byte[] generate(byte[] input, byte[] salt)
        {
            return Sodium.PasswordHash.ScryptHashBinary(input, salt);
        }
        public bool valid(byte[] data, byte[] hash)
        {
            return Sodium.PasswordHash.ScryptHashStringVerify(hash, data);
        }
        public string primitiveName => "Scrypt";
        public string primitiveVariation => "outputLength=32";
        public string implementationName => "LibSodium";
    }
}