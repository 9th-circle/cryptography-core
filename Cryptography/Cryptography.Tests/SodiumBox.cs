using Cryptography.LibSodium;
using System;
using System.Text;
using Xunit;

namespace Cryptography.Tests
{
    public class SodiumBox
    {
        [Fact]
        public void simpleSecretBox()
        {
            var box = new SodiumSecretBox();
            var key = box.generateKey();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, key);
            var decrypted = box.decrypt(encrypted, key);

            Assert.Equal(data,decrypted);
            Assert.NotEqual(encrypted,decrypted);
        }
        [Fact]
        public void simplePublicKeyBox()
        {
            var box = new SodiumPublicKeyBox();
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
        }
    }
}