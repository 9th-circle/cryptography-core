using System.IO;
using Cryptography.Interfaces;

namespace Cryptography.LibSodium
{
    class SodiumSecretBox : ISymmetricBox
    {
        public byte[] generateKey() {
            var m = new MemoryStream();
            var w = new BinaryWriter(m);
            var key = Sodium.SecretBox.GenerateKey();
            var nonce = Sodium.SecretBox.GenerateNonce();
            w.Write(key.Length);
            w.Write(key);
            w.Write(nonce.Length);
            w.Write(nonce);
            return m.ToArray();
        }
        public byte[] encrypt(byte[] data, byte[] keyPackage)
        {
            var m = new MemoryStream(keyPackage);
            var r = new BinaryReader(m);
            var keyLength = r.ReadInt32();
            var key = r.ReadBytes(keyLength);
            var nonceLength = r.ReadInt32();
            var nonce = r.ReadBytes(nonceLength);
            return Sodium.SecretBox.Create(data, nonce, key);
        }
        public byte[] decrypt(byte[] data, byte[] keyPackage)
        {
            var m = new MemoryStream(keyPackage);
            var r = new BinaryReader(m);
            var keyLength = r.ReadInt32();
            var key = r.ReadBytes(keyLength);
            var nonceLength = r.ReadInt32();
            var nonce = r.ReadBytes(nonceLength);
            return Sodium.SecretBox.Open(data, nonce, key);
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingMACPrimitiveName => "Poly1305";
    }
}