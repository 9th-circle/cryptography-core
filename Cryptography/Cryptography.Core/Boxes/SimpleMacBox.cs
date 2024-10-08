﻿#if DEBUG       //This construction has not been validated/examined enough for production use.
using System.Collections.Generic;
using System.Linq;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;
using Cryptography.Interfaces.Constructions;
using Audit.Interfaces.Annotations.SecurityConcern;
using Audit.Interfaces.Annotations.SecurityCritical;

namespace Cryptography.Core.Boxes
{
    /// <summary>
    /// A construction where you can share encrypted + authenticated data with someone you have decided on a shared authentication key for,
    /// but have exchanged public keys for the encryption of the actual data.
    /// </summary>
    [ImmatureConstructionSecurityConcern]
    [SecurityCriticalThatThisIsNotUsed]
    public class SimpleMacBox : IMacBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        IAsymmetricCipher asymmetric;
        IPacker keyPacker;
        public SimpleMacBox(IMAC mac, ISymmetricCipher symmetric, IAsymmetricCipher asymmetric, IPacker keyPacker)
        {
            this.mac = mac;
            this.symmetric = symmetric;
            this.asymmetric = asymmetric;
            this.keyPacker = keyPacker;
        }
        public byte[] generateSharedKey()
        {
            return symmetric.generateNonce();
        }
        public (byte[] senderKey, byte[] receiverKey) generateKeyPair()
        {
            var macKey = generateSharedKey();
            var asymKeyPair = asymmetric.generateKeyPair();

            lock (keyPacker)
            {
                keyPacker.clear();
                keyPacker.pack(macKey);
                keyPacker.pack(asymKeyPair.publicKey);
                var publicKeys = keyPacker.getOutput();

                keyPacker.clear();
                keyPacker.pack(macKey);
                keyPacker.pack(asymKeyPair.privateKey);
                var privateKeys = keyPacker.getOutput();

                return (publicKeys, privateKeys);
            }
        }

        public byte[] encrypt(byte[] data, byte[] senderKey, byte[] shared)
        {
            try
            {
                lock (keyPacker)
                {
                    keyPacker.load(senderKey);
                    var macKey = keyPacker.unPack();
                    var asymPublicKey = keyPacker.unPack();

                    var singleKey = symmetric.generateKey();

                    var encryptedPackage = asymmetric.encrypt(singleKey, asymPublicKey);
                    var encryptedData = symmetric.encrypt(data, singleKey, shared);

                    List<byte> combined = new List<byte>();
                    combined.AddRange(encryptedPackage);
                    combined.AddRange(shared);
                    combined.AddRange(encryptedData);

                    keyPacker.clear();
                    keyPacker.pack(mac.generate(combined.ToArray(), macKey));
                    keyPacker.pack(encryptedPackage);
                    keyPacker.pack(encryptedData);

                    return keyPacker.getOutput();
                }
            }
            catch
            {
                return null; // you looked at it funny, now it's blanking you
            }
        }

        public byte[] decrypt(byte[] data, byte[] receiverKey, byte[] shared)
        {
            try
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

                    if (!mac.generate(combined.ToArray(), macKey).SequenceEqual(combinedSignature))
                        return null;

                    var singleKey = asymmetric.decrypt(encryptedPackage, asymPrivateKey);

                    return symmetric.decrypt(encryptedData, singleKey, shared);
                }
            }
            catch
            {
                return null; // even johnny tightlips actually uses words
            }
        }

        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingAsymmetricPrimitiveName => asymmetric.primitiveName;
        public string underlyingMACPrimitiveName => mac.primitiveName;
    }
}
#endif