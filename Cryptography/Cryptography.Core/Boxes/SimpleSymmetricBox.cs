using System;
using System.Linq;
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
        
        public byte[] generateKey()
        {
            lock (keyPacker)
            {
                keyPacker.clear();
                var symmetricKey = symmetric.generateKey();
                var symmetricNonce = symmetric.generateNonce();
                var macKey = symmetric.generateKey();

                keyPacker.packKey(symmetricKey);
                keyPacker.packKey(symmetricNonce);
                keyPacker.packKey(macKey);

                return keyPacker.getOutput();
            }
        }
        public byte[] encrypt(byte[] data, byte[] key)
        {
            lock (keyPacker)
            {
                keyPacker.load(key);
                var symmetricKey = keyPacker.unPackKey();
                var nonce = keyPacker.unPackKey();
                var macKey = keyPacker.unPackKey();

                keyPacker.load(new byte[] { });

                var ciphertext = symmetric.encrypt(data, symmetricKey, nonce);
                var macOutput = mac.generate(ciphertext, macKey);
                keyPacker.packKey(macOutput);
                keyPacker.packKey(ciphertext);
                return keyPacker.getOutput();
            }
        }
        public byte[] decrypt(byte[] data, byte[] key)
        {
            lock (keyPacker)
            {
                keyPacker.load(key);
                var symmetricKey = keyPacker.unPackKey();
                var nonce = keyPacker.unPackKey();
                var macKey = keyPacker.unPackKey();

                keyPacker.load(data);
                var macValue = keyPacker.unPackKey();
                var cipherContents = keyPacker.unPackKey();

                if (!mac.generate(data, macKey).SequenceEqual(macValue))
                    return null;

                return symmetric.decrypt(cipherContents, symmetricKey, nonce);
            }
        }
        
        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingMACPrimitiveName => mac.primitiveName;
    }
}