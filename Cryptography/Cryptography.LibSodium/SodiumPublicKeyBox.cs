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
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var keys = Sodium.PublicKeyBox.GenerateKeyPair();
            return (keys.PublicKey, keys.PrivateKey);
        }
        public byte[] generateNonce()
        {
            return Sodium.PublicKeyBox.GenerateNonce();
        }
        public byte[] encrypt(byte[] data, byte[] secretKey, byte[] publicKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Create(data, shared, secretKey, publicKey);
        }
        public byte[] decrypt(byte[] data, byte[] secretKey, byte[] publicKey, byte[] shared)
        {
            return Sodium.PublicKeyBox.Open(data, shared, secretKey, publicKey);
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingSignaturePrimitiveName => "Poly1305";
        public string underlyingAsymmetricPrimitiveName => "X25519";
    }
}
