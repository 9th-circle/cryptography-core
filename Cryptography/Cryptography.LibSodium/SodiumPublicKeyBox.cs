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
        public (byte[] publicKey, byte[] privateKey, byte[] shared) generateKeyPair()
        {
            var keys = Sodium.PublicKeyBox.GenerateKeyPair();
            return (keys.PublicKey, keys.PrivateKey, Sodium.PublicKeyBox.GenerateNonce());
        }
        public byte[] encrypt(byte[] data, byte[] publicKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Create(data, shared, null, publicKey);
        }
        public byte[] decrypt(byte[] data, byte[] privateKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Open(data, shared, privateKey, null);
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingMACPrimitiveName => "Poly1305";
        public string underlyingAsymmetricPrimitiveName => "X25519";
    }
}
