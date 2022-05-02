using System.Collections.Generic;
using System.Linq;
using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleSignedBox : ISignedBox
    {
        ISignatureCipher signature;
        ISymmetricCipher symmetric;
        IPacker keyPacker;
        public SimpleSignedBox(ISignatureCipher signature, ISymmetricCipher symmetric, IPacker keyPacker)
        {
            this.signature = signature;
            this.symmetric = symmetric;
            this.keyPacker = keyPacker;
        }
        public byte[] generateSharedKey()
        {
            keyPacker.clear();
            keyPacker.pack(symmetric.generateNonce());
            keyPacker.pack(symmetric.generateKey());
            return keyPacker.getOutput();
        }
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var sigKey = signature.generateKeyPair();
            
            return (sigKey.publicKey, sigKey.privateKey);
        }

        public byte[] encrypt(byte[] data, byte[] privateKey, byte[] shared)
        {
            lock (keyPacker)
            {
                keyPacker.load(shared);
                var nonce = keyPacker.unPack();
                var key = keyPacker.unPack();

                var ciphertext = symmetric.encrypt(data, key, nonce);
                var signature = this.signature.sign(ciphertext, privateKey);

                keyPacker.clear();
                keyPacker.pack(signature);
                keyPacker.pack(ciphertext);

                return keyPacker.getOutput();
            }
        }

        public byte[] decrypt(byte[] data, byte[] publicKey, byte[] shared)
        {
            keyPacker.load(shared);
            var nonce = keyPacker.unPack();
            var key = keyPacker.unPack();

            keyPacker.load(data);
            var signature = keyPacker.unPack();
            var ciphertext = keyPacker.unPack();

            if (!this.signature.signatureIsValid(ciphertext, publicKey, signature))
                return null;

            return symmetric.decrypt(ciphertext, key, nonce);
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingSignaturePrimitiveName => signature.primitiveName;
    }
}