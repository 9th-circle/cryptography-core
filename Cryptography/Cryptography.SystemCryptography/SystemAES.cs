using Cryptography.Interfaces;

namespace Cryptography.SystemCryptography
{
    public class SystemAES : ISymmetricCipher
    {

        public byte[] generateKey()
        {
            return null;
        }
        public byte[] generateNonce()
        {
            return null;
        }
        public byte[] encrypt(byte[] data, byte[] key, byte[] nonce)
        {
            return null;
        }
        public byte[] decrypt(byte[] data, byte[] key, byte[] nonce)
        {
            return null;
        }
        public string primitiveName => "AES";
        public string primitiveVariation => "KeySize=256";
        public string implementationName => "System.Security.Cryptography";
    }
}