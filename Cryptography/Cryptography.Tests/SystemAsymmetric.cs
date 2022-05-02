using Cryptography.SystemCryptography;
using Xunit;

namespace Cryptography.Tests
{
    public class SystemAsymmetric
    {

        [Fact]
        public void basicRSA()
        {
            byte[] data = new byte[64];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)i;

            var rsa = new SystemRSA();
            var keys = rsa.generateKeyPair();

            var encrypted = rsa.encrypt(data, keys.publicKey);
            var decrypted = rsa.decrypt(encrypted, keys.privateKey);

            Assert.NotEqual(encrypted, decrypted);
            Assert.Equal(data, decrypted);
        }
    }
}