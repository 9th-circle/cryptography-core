using Cryptography.Core;
using Cryptography.LibSodium;
using Cryptography.SystemCryptography;
using Xunit;

namespace Cryptography.Tests
{
    public class CoreBox
    {
        [Fact]
        public void simpleSymmetric()
        {
            var box = new Core.Boxes.SimpleSymmetricBox(new SystemHMAC_SHA512(), new SystemAES(), new PrefixPacker());
            var key = box.generateKey();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, key);
            var decrypted = box.decrypt(encrypted, key);

            Assert.Equal(data, decrypted);
            Assert.NotEqual(encrypted, decrypted);
        }
        [Fact]
        public void simpleMacBox()
        {
            var box = new Core.Boxes.SimpleMacBox(new SystemHMAC_SHA512(), new SystemAES(), new SystemRSA(), new PrefixPacker());
            var keys = box.generateKeyPair();
            var nonce = box.generateNonce();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, keys.senderKey, nonce);
            var decrypted = box.decrypt(encrypted, keys.receiverKey, nonce);

            Assert.Equal(data, decrypted);
            Assert.NotEqual(encrypted, decrypted);
        }
    }
}