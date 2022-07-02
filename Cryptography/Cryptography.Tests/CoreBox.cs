using Cryptography.Core;
using Cryptography.Interfaces.Primitives;
using Cryptography.Interfaces.Constructions;
using Cryptography.LibSodium;
using Cryptography.SystemCryptography;
using Xunit;
#if DEBUG
using Cryptography.Core.Boxes;
#endif

namespace Cryptography.Tests
{
    public class CoreBox
    {
#if DEBUG
        [Fact]
        public void simpleSymmetric()
        {
            var box = new SimpleSymmetricBox(new SystemHMAC_SHA512(), new SystemAES_CBC(), new PrefixPacker());
            var key = box.generateKey();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, key);
            var decrypted = box.decrypt(encrypted, key);

            Assert.Equal(data, decrypted);
            Assert.NotEqual(encrypted, decrypted);
            
            encrypted[3] = (byte)(encrypted[3] ^ 255);
            Assert.Null(box.decrypt(encrypted, key));
        }
        [Fact]
        public void simpleSignedBox()
        {
            var box = new SimpleSignedBox(new SystemDSA(), new SystemAES_CBC(), new PrefixPacker());
            var keys = box.generateKeyPair();
            var shared = box.generateSharedKey();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, keys.privateKey, shared);
            var decrypted = box.decrypt(encrypted, keys.publicKey, shared);

            Assert.Equal(data, decrypted);
            Assert.NotEqual(encrypted, decrypted);

            encrypted[3] = (byte)(encrypted[3] ^ 255);
            Assert.Null(box.decrypt(encrypted, keys.publicKey, shared));
        }
        [Fact]
        public void simpleMacBox()
        {
            var box = new SimpleMacBox(new SystemHMAC_SHA512(), new SystemAES_CBC(), new SystemRSA(), new PrefixPacker());
            var keys = box.generateKeyPair();
            var nonce = box.generateSharedKey();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, keys.senderKey, nonce);
            var decrypted = box.decrypt(encrypted, keys.receiverKey, nonce);

            Assert.Equal(data, decrypted);
            Assert.NotEqual(encrypted, decrypted);
            
            encrypted[3] = (byte)(encrypted[3] ^ 255);
            Assert.Null(box.decrypt(encrypted, keys.receiverKey, nonce));
        }
        [Fact]
        public void simpleAsymmetricBox()
        {
            var box = new SimpleAsymmetricBox(new SystemDSA(), new SystemAES_CBC(), new SystemRSA(), new PrefixPacker());
            var senderKeys = box.generateKeyPair();
            var receiverKeys = box.generateKeyPair();
            var nonce = box.generateNonce();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, senderKeys.privateKey, receiverKeys.publicKey, nonce);
            var decrypted = box.decrypt(encrypted, receiverKeys.privateKey, senderKeys.publicKey, nonce);

            Assert.Equal(data, decrypted);
            Assert.NotEqual(encrypted, decrypted);
            
            encrypted[3] = (byte)(encrypted[3] ^ 255);
            Assert.Null(box.decrypt(encrypted, receiverKeys.privateKey, senderKeys.publicKey, nonce));
        }
#endif
    }
}