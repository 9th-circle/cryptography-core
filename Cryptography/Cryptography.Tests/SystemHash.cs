using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.SystemCryptography;
using Xunit;

namespace Cryptography.Tests
{
    public class SystemHash
    {
        [Fact]
        public void md5()
        {
            var hash = new SystemMD5();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("+iv9dVB7Mgaz3O43tigt1A==", Convert.ToBase64String(output));
        }

    }
}
