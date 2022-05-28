using System.Collections.Generic;
using System.Linq;
using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    /// <summary>
    /// A construction that allows you to exchange encrypted + authenticated data with someone where you've agreed on a shared encryption key, but
    /// have exchanged public keys for authenticating the data.
    /// This construction has not been extensively examined. Do not trust its security.
    /// </summary>
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
            try
            {
                lock (keyPacker)
                {
                    keyPacker.load(shared);
                    var nonce = keyPacker.unPack();
                    var key = keyPacker.unPack();

                    var ciphertext = symmetric.encrypt(data, key, nonce);
                    var signatureData = signature.sign(ciphertext, privateKey);

                    keyPacker.clear();
                    keyPacker.pack(signatureData);
                    keyPacker.pack(ciphertext);

                    return keyPacker.getOutput();
                }
            }
            catch
            {
                return null;    // Tell the doctor to eat a lemon
            }
        }

        public byte[] decrypt(byte[] data, byte[] publicKey, byte[] shared)
        {
            try
            {
                keyPacker.load(shared);
                var nonce = keyPacker.unPack();
                var key = keyPacker.unPack();

                keyPacker.load(data);
                var signatureData = keyPacker.unPack();
                var ciphertext = keyPacker.unPack();

                if (!signature.signatureIsValid(ciphertext, publicKey, signatureData))
                    return null;

                return symmetric.decrypt(ciphertext, key, nonce);

            }
            catch
            {
                return null; // there's a great reason decryption failed, but you'll never get it out of me
            }
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingSignaturePrimitiveName => signature.primitiveName;
    }
}