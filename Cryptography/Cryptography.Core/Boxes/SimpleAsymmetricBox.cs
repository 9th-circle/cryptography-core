using System.Collections.Generic;
using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleAsymmetricBox : IAsymmetricBox
    {
        ISignatureCipher signature;
        ISymmetricCipher symmetric;
        IAsymmetricCipher asymmetric;
        IKeyPacker keyPacker;
        public SimpleAsymmetricBox(ISignatureCipher signature, ISymmetricCipher symmetric, IAsymmetricCipher asymmetric, IKeyPacker keyPacker)
        {
            this.signature = signature;
            this.symmetric = symmetric;
            this.asymmetric = asymmetric;
            this.keyPacker = keyPacker;
        }
        public byte[] generateNonce()
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] output = new byte[128];
            rng.GetBytes(output);
            return output;
        }
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var sigKeyPair = signature.generateKeyPair();
            var asymKeyPair = asymmetric.generateKeyPair();

            lock (keyPacker)
            {
                keyPacker.load(new byte[] { });
                keyPacker.packKey(sigKeyPair.privateKey);
                keyPacker.packKey(asymKeyPair.publicKey);
                var publicKeys = keyPacker.getOutput();
                
                keyPacker.load(new byte[] { });
                keyPacker.packKey(sigKeyPair.publicKey);
                keyPacker.packKey(asymKeyPair.privateKey);
                var privateKeys = keyPacker.getOutput();
                
                return (publicKeys, privateKeys);
            }
        }

        public byte[] encrypt(byte[] data, byte[] publicKey, byte[] shared)
        {
            lock (keyPacker)
            {
                keyPacker.load(publicKey);
                var sigPrivateKey = keyPacker.unPackKey();
                var asymPublicKey = keyPacker.unPackKey();

                var singleKey = symmetric.generateKey();
                
                var encryptedPackage = asymmetric.encrypt(singleKey, asymPublicKey);
                var encryptedData = symmetric.encrypt(data, singleKey, shared);

                List<byte> combined = new List<byte>();
                combined.AddRange(encryptedPackage);
                combined.AddRange(shared);
                combined.AddRange(encryptedData);

                keyPacker.load(new byte[] { });
                keyPacker.packKey(signature.sign(combined.ToArray(), sigPrivateKey));
                keyPacker.packKey(encryptedPackage);
                keyPacker.packKey(encryptedData);

                return keyPacker.getOutput();
            }
        }

        public byte[] decrypt(byte[] data, byte[] privateKey, byte[] shared)
        {
            lock (keyPacker)
            {
                keyPacker.load(privateKey);
                var sigPublicKey = keyPacker.unPackKey();
                var asymPrivateKey = keyPacker.unPackKey();

                keyPacker.load(data);
                var combinedSignature = keyPacker.unPackKey();
                var encryptedPackage = keyPacker.unPackKey();
                var encryptedData = keyPacker.unPackKey();

                List<byte> combined = new List<byte>();
                combined.AddRange(encryptedPackage);
                combined.AddRange(shared);
                combined.AddRange(encryptedData);

                if (!signature.signatureIsValid(combined.ToArray(), sigPublicKey, combinedSignature))
                    return null;

                var singleKey = asymmetric.decrypt(encryptedPackage, asymPrivateKey);
                
                return symmetric.decrypt(encryptedData, singleKey, shared);
            }
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingAsymmetricPrimitiveName => asymmetric.primitiveName;
        public string underlyingSignaturePrimitiveName => signature.primitiveName;
    }
}