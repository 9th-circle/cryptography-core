using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.LibSodium
{
    public class SodiumPublicKeyBox : IAsymmetricBox
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
        public byte[] encrypt(byte[] data, byte[] receiverKey, byte[] senderKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Create(data, shared, receiverKey, senderKey);
        }
        public byte[] decrypt(byte[] data, byte[] receiverKey, byte[] senderKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Open(data, shared, receiverKey, senderKey);
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingSignaturePrimitiveName => "Poly1305";
        public string underlyingAsymmetricPrimitiveName => "X25519";
    }
}
