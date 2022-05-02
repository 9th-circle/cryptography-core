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
            IKeyPacker p = new PrefixKeyPacker();
            p.packKey(key);
            p.packKey(nonce);
            return p.getOutput();
        }
        public byte[] encrypt(byte[] data, byte[] keyPackage)
        {
            IKeyPacker p = new PrefixKeyPacker();
            p.load(keyPackage);
            var key = p.unPackKey();
            var nonce = p.unPackKey();
            return Sodium.SecretBox.Create(data, nonce, key);
        }
        public byte[] decrypt(byte[] data, byte[] keyPackage)
        {
            IKeyPacker p = new PrefixKeyPacker();
            p.load(keyPackage);
            var key = p.unPackKey();
            var nonce = p.unPackKey();
            return Sodium.SecretBox.Open(data, nonce, key);
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingMACPrimitiveName => "Poly1305";
    }
}