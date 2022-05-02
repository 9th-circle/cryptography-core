using System.Collections.Generic;
using System.Linq;
using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleAsymmetricBox : IAsymmetricBox
    {
        ISignatureCipher signature;
        ISymmetricCipher symmetric;
        IAsymmetricCipher asymmetric;
        IPacker keyPacker;
        public SimpleAsymmetricBox(ISignatureCipher signature, ISymmetricCipher symmetric, IAsymmetricCipher asymmetric, IPacker keyPacker)
        {
            this.signature = signature;
            this.symmetric = symmetric;
            this.asymmetric = asymmetric;
            this.keyPacker = keyPacker;
        }
        public byte[] generateNonce()
        {
            return symmetric.generateNonce();
        }
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var sigKey = signature.generateKeyPair();
            var asymKeyPair = asymmetric.generateKeyPair();

            lock (keyPacker)
            {
                keyPacker.clear();
                keyPacker.pack(sigKey.publicKey);
                keyPacker.pack(asymKeyPair.publicKey);
                var publicKeys = keyPacker.getOutput();

                keyPacker.clear();
                keyPacker.pack(sigKey.privateKey);
                keyPacker.pack(asymKeyPair.privateKey);
                var privateKeys = keyPacker.getOutput();

                return (publicKeys, privateKeys);
            }
        }

        public byte[] encrypt(byte[] data, byte[] senderKey, byte[] receiverKey, byte[] shared)
        {
            lock (keyPacker)
            {
                keyPacker.load(senderKey);
                var signatureKey = keyPacker.unPack();
                var asymPublicKey = keyPacker.unPack();

                var singleKey = symmetric.generateKey();

                var encryptedPackage = asymmetric.encrypt(singleKey, asymPublicKey);
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
            }
        }

        public byte[] decrypt(byte[] data, byte[] senderKey, byte[] receiverKey, byte[] shared)
        {
            lock (keyPacker)
            {
                keyPacker.load(receiverKey);
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
            }
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingAsymmetricPrimitiveName => asymmetric.primitiveName;
        public string underlyingSignaturePrimitiveName => signature.primitiveName;
    }
}