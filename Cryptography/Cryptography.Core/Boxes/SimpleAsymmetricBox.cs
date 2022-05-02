/*using System.Collections.Generic;
using System.Linq;
using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleAsymmetricBox : IAsymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        IAsymmetricCipher asymmetric;
        IKeyPacker keyPacker;
        public SimpleAsymmetricBox(IMAC mac, ISymmetricCipher symmetric, IAsymmetricCipher asymmetric, IKeyPacker keyPacker)
        {
            this.mac = mac;
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
        public (byte[] senderKey, byte[] receiverKey) generateKeyPair()
        {
            var macKey = generateNonce();
            var asymKeyPair = asymmetric.generateKeyPair();

            lock (keyPacker)
            {
                keyPacker.clear();
                keyPacker.packKey(macKey);
                keyPacker.packKey(asymKeyPair.publicKey);
                var publicKeys = keyPacker.getOutput();

                keyPacker.clear();
                keyPacker.packKey(macKey);
                keyPacker.packKey(asymKeyPair.privateKey);
                var privateKeys = keyPacker.getOutput();

                return (publicKeys, privateKeys);
            }
        }

        public byte[] encrypt(byte[] data, byte[] receiverKey, byte[] senderKey, byte[] shared)
        {
            lock (keyPacker)
            {
                keyPacker.load(senderKey);
                var macKey = keyPacker.unPackKey();
                var asymPublicKey = keyPacker.unPackKey();

                var singleKey = symmetric.generateKey();

                var encryptedPackage = asymmetric.encrypt(singleKey, asymPublicKey);
                var encryptedData = symmetric.encrypt(data, singleKey, shared);

                List<byte> combined = new List<byte>();
                combined.AddRange(encryptedPackage);
                combined.AddRange(shared);
                combined.AddRange(encryptedData);

                keyPacker.clear();
                keyPacker.packKey(mac.generate(combined.ToArray(), macKey));
                keyPacker.packKey(encryptedPackage);
                keyPacker.packKey(encryptedData);

                return keyPacker.getOutput();
            }
        }

        public byte[] decrypt(byte[] data, byte[] receiverKey, byte[] shared)
        {
            lock (keyPacker)
            {
                keyPacker.load(receiverKey);
                var macKey = keyPacker.unPackKey();
                var asymPrivateKey = keyPacker.unPackKey();

                keyPacker.load(data);
                var combinedSignature = keyPacker.unPackKey();
                var encryptedPackage = keyPacker.unPackKey();
                var encryptedData = keyPacker.unPackKey();

                List<byte> combined = new List<byte>();
                combined.AddRange(encryptedPackage);
                combined.AddRange(shared);
                combined.AddRange(encryptedData);

                if (!mac.generate(combined.ToArray(), macKey).SequenceEqual(combinedSignature))
                    return null;

                var singleKey = asymmetric.decrypt(encryptedPackage, asymPrivateKey);

                return symmetric.decrypt(encryptedData, singleKey, shared);
            }
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingAsymmetricPrimitiveName => asymmetric.primitiveName;
        public string underlyingMACPrimitiveName => mac.primitiveName;
    }
}*/