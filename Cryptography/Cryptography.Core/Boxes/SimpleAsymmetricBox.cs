#if DEBUG       //This construction has not been validated/examined enough for production use.
using System.Collections.Generic;
using System.Linq;
using Audit.Interfaces.Annotations;
using Audit.Interfaces.Annotations.SecurityConcern;
using Audit.Interfaces.Annotations.SecurityCritical;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;
using Cryptography.Interfaces.Constructions;

namespace Cryptography.Core.Boxes
{
    /// <summary>
    /// A construction that allows you to send/receive encrypted & authenticated data with someone you've exchanged public keys with.
    /// This is the construction which Latacora famously said was the least likely for the average programmer to get right on their own.
    /// </summary>
    [ImmatureConstructionSecurityConcern]
    [SecurityCriticalThatThisIsNotUsed]
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

        public byte[] encrypt(byte[] data, byte[] senderPrivateKey, byte[] receiverPublicKey, byte[] shared)
        {
            try
            {
                lock (keyPacker)
                {
                    keyPacker.load(senderPrivateKey);
                    var signaturePrivateKey = keyPacker.unPack();
                    var asymPrivateKey = keyPacker.unPack();

                    keyPacker.load(receiverPublicKey);
                    var signaturePublicKey = keyPacker.unPack();
                    var asymPublicKey = keyPacker.unPack();

                    var singleKey = symmetric.generateKey();

                    var encryptedPackage = asymmetric.encrypt(singleKey, asymPublicKey);
                    var encryptedData = symmetric.encrypt(data, singleKey, shared);

                    List<byte> combined = new List<byte>();
                    combined.AddRange(encryptedPackage);
                    combined.AddRange(shared);
                    combined.AddRange(encryptedData);

                    keyPacker.clear();
                    keyPacker.pack(signature.sign(combined.ToArray(), signaturePrivateKey));
                    keyPacker.pack(encryptedPackage);
                    keyPacker.pack(encryptedData);

                    return keyPacker.getOutput();
                }
            }
            catch
            {
                return null; // make debugging as hard as possible by giving no indication whatsoever of how or why it failed
            }
        }

        public byte[] decrypt(byte[] data, byte[] receiverPrivateKey, byte[] senderPublicKey, byte[] shared)
        {
            try
            {
                lock (keyPacker)
                {
                    keyPacker.load(receiverPrivateKey);
                    var signaturePrivateKey = keyPacker.unPack();
                    var asymPrivateKey = keyPacker.unPack();

                    keyPacker.load(senderPublicKey);
                    var signaturePublicKey = keyPacker.unPack();
                    var asymPublicKey = keyPacker.unPack();

                    keyPacker.load(data);
                    var combinedSignature = keyPacker.unPack();
                    var encryptedPackage = keyPacker.unPack();
                    var encryptedData = keyPacker.unPack();

                    List<byte> combined = new List<byte>();
                    combined.AddRange(encryptedPackage);
                    combined.AddRange(shared);
                    combined.AddRange(encryptedData);

                    if (!signature.signatureIsValid(combined.ToArray(), signaturePublicKey, combinedSignature))
                        return null;

                    var singleKey = asymmetric.decrypt(encryptedPackage, asymPrivateKey);

                    return symmetric.decrypt(encryptedData, singleKey, shared);
                }
            }
            catch
            {
                return null; //hope your unit tests are good lol
            }
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingAsymmetricPrimitiveName => asymmetric.primitiveName;
        public string underlyingSignaturePrimitiveName => signature.primitiveName;
    }
}
#endif