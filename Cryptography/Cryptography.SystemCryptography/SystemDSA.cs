using System.Security.Cryptography;
using Cryptography.Interfaces;

namespace Cryptography.SystemCryptography
{
    public class SystemDSA : ISignatureCipher
    {
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var dsa = new DSACryptoServiceProvider();

            return (null, null);
        }
        public byte[] sign(byte[] data, byte[] privateKey)
        {
            return null;
        }
        public bool signatureIsValid(byte[] data, byte[] publicKey)
        {
            return false;
        }
        public string primitiveName => "DSA";
        public string primitiveVariation => null;
        public string implementationName => "System.Cryptography";
    }
}