using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cryptography.SystemCryptography;

namespace Cryptography.Tests
{
    public class SystemSignature
    {
#if DEBUG
        [Fact]
        public void basicDSA()
        {
            byte[] data = new byte[64];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)i;

            var rsa = new SystemDSA();
            var keys = rsa.generateKeyPair();

            var signature = rsa.sign(data, keys.privateKey);

            Assert.True(rsa.signatureIsValid(data,keys.publicKey,signature));
            Assert.False(rsa.signatureIsValid(data, keys.publicKey, data));
        }
#endif
    }
}
