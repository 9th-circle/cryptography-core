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
    }
}