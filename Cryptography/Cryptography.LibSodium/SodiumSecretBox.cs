using System.IO;
using Cryptography.Core;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Constructions;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// A construction for encrypting + authenticating data where both parties have agreed on a single shared key for
    /// both authentication and encryption.
    /// </summary>
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
            try
            {
                IPacker p = new PrefixPacker();
                p.load(keyPackage);
                var key = p.unPack();
                var nonce = p.unPack();
                return Sodium.SecretBox.Create(data, nonce, key);
            }
            catch
            {
                return null;
            }
        }
        public byte[] decrypt(byte[] data, byte[] keyPackage)
        {
            try
            {
                IPacker p = new PrefixPacker();
                p.load(keyPackage);
                var key = p.unPack();
                var nonce = p.unPack();
                return Sodium.SecretBox.Open(data, nonce, key);
            }
            catch
            {
                return null;
            }
        }

        public string underlyingSymmetricPrimitiveName => "XSalsa20";
        public string underlyingMACPrimitiveName => "Poly1305";
    }
}