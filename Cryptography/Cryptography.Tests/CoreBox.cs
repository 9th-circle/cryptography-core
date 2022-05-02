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
            var box = new Core.Boxes.SimpleSymmetricBox(new SystemHMAC_SHA512(), new SystemAES(), new PrefixKeyPacker());
            var key = box.generateKey();

            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var encrypted = box.encrypt(data, key);
            var decrypted = box.decrypt(encrypted, key);

            Assert.Equal(data, decrypted);
            Assert.NotEqual(encrypted, decrypted);
        }
    }
}