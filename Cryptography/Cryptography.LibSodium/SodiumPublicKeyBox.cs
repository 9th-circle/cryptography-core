using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.LibSodium
{
    class SodiumPublicKeyBox : IAsymmetricBox
    {
        public (byte[] senderKey, byte[] receiverKey) generateKeyPair()
        {
            var keys = Sodium.PublicKeyBox.GenerateKeyPair();
            return (keys.PublicKey, keys.PrivateKey);
        }
        public byte[] generateNonce()
        {
            return Sodium.PublicKeyBox.GenerateNonce();
        }
        public byte[] encrypt(byte[] data, byte[] senderKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Create(data, shared, null, senderKey);
        }
        public byte[] decrypt(byte[] data, byte[] receiverKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Open(data, shared, receiverKey, null);
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingMACPrimitiveName => "Poly1305";
        public string underlyingAsymmetricPrimitiveName => "X25519";
    }
}
