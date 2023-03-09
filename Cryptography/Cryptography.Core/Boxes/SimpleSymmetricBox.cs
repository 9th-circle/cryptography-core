#if DEBUG       //This construction has not been validated/examined enough for production use.
using System;
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
    /// A construction for encrypting + authenticating data where both parties have agreed on a single shared key for
    /// both authentication and encryption.
    /// This construction has not been extensively examined. Do not trust its security.
    /// It is not suitable for production systems.
    /// </summary>
    [ImmatureConstructionSecurityConcern]
    [SecurityCriticalThatThisIsNotUsed]
    public class SimpleSymmetricBox : ISymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        IPacker keyPacker;
        public SimpleSymmetricBox(IMAC mac, ISymmetricCipher symmetric, IPacker keyPacker)
        {
            this.mac = mac;
            this.symmetric = symmetric;
            this.keyPacker = keyPacker;
        }

        public byte[] deriveKey(byte[] input)
        {

        }
        public byte[] generateKey()
        {
            lock (keyPacker)
            {
                keyPacker.clear();
                var symmetricKey = symmetric.generateKey();
                var symmetricNonce = symmetric.generateNonce();
                var macKey = symmetric.generateKey();

                keyPacker.pack(symmetricKey);
                keyPacker.pack(symmetricNonce);
                keyPacker.pack(macKey);

                return keyPacker.getOutput();
            }
        }
        public byte[] encrypt(byte[] data, byte[] key)
        {
            try
            {
                lock (keyPacker)
                {
                    keyPacker.load(key);
                    var symmetricKey = keyPacker.unPack();
                    var nonce = keyPacker.unPack();
                    var macKey = keyPacker.unPack();

                    keyPacker.load(new byte[] { });

                    var ciphertext = symmetric.encrypt(data, symmetricKey, nonce);
                    var macOutput = mac.generate(ciphertext, macKey);
                    keyPacker.pack(macOutput);
                    keyPacker.pack(ciphertext);
                    return keyPacker.getOutput();
                }
            }
            catch
            {
                return null; // woahwee, who says I have a mother?
            }
        }
        public byte[] decrypt(byte[] data, byte[] key)
        {
            try
            {
                lock (keyPacker)
                {
                    keyPacker.load(key);
                    var symmetricKey = keyPacker.unPack();
                    var nonce = keyPacker.unPack();
                    var macKey = keyPacker.unPack();

                    keyPacker.load(data);
                    var macValue = keyPacker.unPack();
                    var cipherContents = keyPacker.unPack();

                    if (!mac.generate(cipherContents, macKey).SequenceEqual(macValue))
                        return null;

                    return symmetric.decrypt(cipherContents, symmetricKey, nonce);
                }
            }
            catch
            {
                return null; // Anyone here own a black Lincoln Continental, license plate "ZERO2SAY"?
            }
        }


        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingMACPrimitiveName => mac.primitiveName;
    }
}
#endif