using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleSymmetricBox : ISymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        public SimpleSymmetricBox(IMAC mac, ISymmetricCipher symmetric)
        {
            this.mac = mac;
            this.symmetric = symmetric;
        }
        
        public byte[] generateKey() { return null; }
        public byte[] encrypt(byte[] data, byte[] key) { return null; }
        public byte[] decrypt(byte[] data, byte[] key) { return null; }
        
        public string underlyingSymmetricPrimitiveName { get; }
        public string underlyingMACPrimitiveName { get; }
    }
}