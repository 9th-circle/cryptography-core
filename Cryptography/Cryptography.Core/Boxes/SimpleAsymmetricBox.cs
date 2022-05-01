using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleAsymmetricBox : IAsymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        IAsymmetricCipher asymmetric;
        public SimpleAsymmetricBox(IMAC mac, ISymmetricCipher symmetric, IAsymmetricCipher asymmetric)
        {
            this.mac = mac;
            this.symmetric = symmetric;
            this.asymmetric = asymmetric;
        }

        public (byte[] publicKey, byte[] privateKey, byte[] shared) generateKeyPair()
        {
            return (null, null, null);
        }
        public byte[] encrypt(byte[] data, byte[] publicKey, byte[] shared)
        {
            return null;
        }
        public byte[] decrypt(byte[] data, byte[] privateKey, byte[] shared)
        {
            return null;
        }
        public string underlyingSymmetricPrimitiveName { get; }
        public string underlyingAsymmetricPrimitiveName { get; }
        public string underlyingMACPrimitiveName { get; }
    }
}