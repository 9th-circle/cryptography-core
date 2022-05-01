using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleSymmetricBox : ISymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        IKeyPacker keyPacker;
        public SimpleSymmetricBox(IMAC mac, ISymmetricCipher symmetric, IKeyPacker keyPacker)
        {
            this.mac = mac;
            this.symmetric = symmetric;
            this.keyPacker = keyPacker;
        }
        
        public byte[] generateKey() { return null; }
        public byte[] encrypt(byte[] data, byte[] key) { return null; }
        public byte[] decrypt(byte[] data, byte[] key)
        {
            keyPacker.load(key);
            var symmetricKey = keyPacker.unPackKey();
            var macKey = keyPacker.unPackKey();

            return null;
        }
        
        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingMACPrimitiveName => mac.primitiveName;
    }
}