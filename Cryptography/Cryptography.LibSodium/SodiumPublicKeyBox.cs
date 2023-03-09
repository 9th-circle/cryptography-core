using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Constructions;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// A construction that allows you to send/receive encrypted & authenticated data with someone you've exchanged public keys with.
    /// </summary>
    [SecurityCritical]
    public class SodiumPublicKeyBox : IAsymmetricBox
    {
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var keys = Sodium.PublicKeyBox.GenerateKeyPair();
            return (keys.PublicKey, keys.PrivateKey);
        }

        public byte[] generateNonce()
        {
            return Sodium.PublicKeyBox.GenerateNonce();
        }

        public byte[] encrypt(byte[] data, byte[] senderPrivateKey, byte[] receiverPublicKey, byte[] shared)
        {
            try
            {
                return Sodium.PublicKeyBox.Create(data, shared, senderPrivateKey, receiverPublicKey);
            }
            catch
            {
                return null;
            }
        }

        public byte[] decrypt(byte[] data, byte[] receiverPrivateKey, byte[] senderPublicKey, byte[] shared)
        {
            try
            {
                return Sodium.PublicKeyBox.Open(data, shared, receiverPrivateKey, senderPublicKey);
            }
            catch
            {
                return null;
            }
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingSignaturePrimitiveName => "Poly1305";
        public string underlyingAsymmetricPrimitiveName => "X25519";
    }
}
