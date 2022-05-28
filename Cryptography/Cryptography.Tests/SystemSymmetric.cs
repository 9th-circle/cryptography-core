using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.SystemCryptography;
using Xunit;

namespace Cryptography.Tests
{
    public class SystemSymmetric
    {
        [Fact]
        public void basicAES()
        {
            byte[] data = new byte[512];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(i % 256);

            var aes = new SystemAES_CBC();

            var key = aes.generateKey();
            var nonce = aes.generateNonce();

            var encrypted = aes.encrypt(data, key, nonce);

            var decrypted = aes.decrypt(encrypted, key, nonce);

            Assert.NotEqual(encrypted,decrypted);
            Assert.Equal(data,decrypted);
        }
    }
}
