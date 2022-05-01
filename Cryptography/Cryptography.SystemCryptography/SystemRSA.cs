using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemRSA : Interfaces.IAsymmetricCipher
    {
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var rsa = new RSACryptoServiceProvider();

            return (null, null);
        }
        public byte[] encrypt(byte[] data, byte[] publicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            return null;
        }
        public byte[] decrypt(byte[] data, byte[] privateKey)
        {
            var rsa = new RSACryptoServiceProvider();
            return null;
        }
        public string primitiveName => "RSA";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
    }
}