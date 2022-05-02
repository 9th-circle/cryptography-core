using System.IO;
using Cryptography.Core;
using Cryptography.Interfaces;

namespace Cryptography.LibSodium
{
    public class SodiumSecretBox : ISymmetricBox
    {
        public byte[] generateKey() {
            var key = Sodium.SecretBox.GenerateKey();
            var nonce = Sodium.SecretBox.GenerateNonce();
            IPacker p = new PrefixPacker();
            p.pack(key);
            p.pack(nonce);
            return p.getOutput();
        }
        public byte[] encrypt(byte[] data, byte[] keyPackage)
        {
            IPacker p = new PrefixPacker();
            p.load(keyPackage);
            var key = p.unPack();
            var nonce = p.unPack();
            return Sodium.SecretBox.Create(data, nonce, key);
        }
        public byte[] decrypt(byte[] data, byte[] keyPackage)
        {
            IPacker p = new PrefixPacker();
            p.load(keyPackage);
            var key = p.unPack();
            var nonce = p.unPack();
            return Sodium.SecretBox.Open(data, nonce, key);
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingMACPrimitiveName => "Poly1305";
    }
}