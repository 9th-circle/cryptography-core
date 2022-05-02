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
            return symmetric.generateNonce();
        }
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var sigKey = signature.generateKeyPair();
            
            return (sigKey.publicKey, sigKey.privateKey);
        }

        public byte[] encrypt(byte[] data, byte[] privateKey, byte[] shared)
        {
            return null;
            /*
            lock (keyPacker)
            {
                keyPacker.load(privateKey);
                var signatureKey = keyPacker.unPack();
                var asymPublicKey = keyPacker.unPack();

                var singleKey = symmetric.generateKey();

                var encryptedData = symmetric.encrypt(data, singleKey, shared);

                List<byte> combined = new List<byte>();
                combined.AddRange(encryptedPackage);
                combined.AddRange(shared);
                combined.AddRange(encryptedData);

                keyPacker.clear();
                keyPacker.pack(signature.sign(combined.ToArray(), signatureKey));
                keyPacker.pack(encryptedPackage);
                keyPacker.pack(encryptedData);

                return keyPacker.getOutput();
            }*/
        }

        public byte[] decrypt(byte[] data, byte[] publicKey, byte[] shared)
        {
            return null;
            /*
            lock (keyPacker)
            {
                keyPacker.load(privateKey);
                var macKey = keyPacker.unPack();
                var asymPrivateKey = keyPacker.unPack();

                keyPacker.load(data);
                var combinedSignature = keyPacker.unPack();
                var encryptedPackage = keyPacker.unPack();
                var encryptedData = keyPacker.unPack();

                List<byte> combined = new List<byte>();
                combined.AddRange(encryptedPackage);
                combined.AddRange(shared);
                combined.AddRange(encryptedData);

                if (!signature.signatureIsValid(combined.ToArray(), macKey,combinedSignature))
                    return null;

                var singleKey = asymmetric.decrypt(encryptedPackage, asymPrivateKey);

                return symmetric.decrypt(encryptedData, singleKey, shared);
            }*/
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingSignaturePrimitiveName => signature.primitiveName;
    }
}