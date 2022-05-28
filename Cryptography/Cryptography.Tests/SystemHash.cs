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

        [Fact]
        public void sha1()
        {
            var hash = new SystemSHA1();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("viq8gNfX5N6d/Cam0+V35uJRBL8=", Convert.ToBase64String(output));
        }
        [Fact]
        public void sha256()
        {
            var hash = new SystemSHA256();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("K+NbxnHckS5/VA8OWi6RXvakpNvSraW6nB0rEXv8kHw=", Convert.ToBase64String(output));
        }
        [Fact]
        public void sha384()
        {
            var hash = new SystemSHA384();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("dNTLg4v2FoTaNnXn115kQ2oKbExDigTDR55EGhmL0sGV0u0nT1CWSsRuFdZJKi2N", Convert.ToBase64String(output));
        }
        [Fact]
        public void sha512()
        {
            var hash = new SystemSHA512();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("nUxrk0FgDMzvkfErD2SgxXZNJ5kCEkAD6ATFPl3/XVBxQOWcMYB0RT2dPv0zPVg/QSozg6SGmbpsIbd8hj4WVQ==", Convert.ToBase64String(output));
        }
        [Fact]
        public void hmac_sha256()
        {
            var hash = new SystemHMAC_SHA256();
            var output = hash.generate(Encoding.UTF8.GetBytes("some input"), Encoding.UTF8.GetBytes("password"));
            Assert.Equal("dfQhpODRoip/uMqwZLPhxY8g0QzsWNnmVIXH3NybSm0=", Convert.ToBase64String(output));
        }
        [Fact]
        public void hmac_sha384()
        {
            var hash = new SystemHMAC_SHA384();
            var output = hash.generate(Encoding.UTF8.GetBytes("some input"), Encoding.UTF8.GetBytes("password"));
            Assert.Equal("SRpeCjJQgLWoDspI9yrPmbiClJQdQgpKPSMFXfPVwGEcXSx2m0Yxq1XUP2ymTN40", Convert.ToBase64String(output));
        }
        [Fact]
        public void hmac_sha512()
        {
            var hash = new SystemHMAC_SHA512();
            var output = hash.generate(Encoding.UTF8.GetBytes("some input"), Encoding.UTF8.GetBytes("password"));
            Assert.Equal("/byXFzrBIAoJcPgN8vYuvhUY7n42zcusXcXM1+46D+g5KMUxkpkMT4q5+cMbBILrbedQxO177IhBkHrTmJ5PFg==", Convert.ToBase64String(output));
        }
        [Fact]
        public void lengthPrefixed_sha512()
        {
            var hash = new Core.LengthPrefixedHash(new SystemSHA512());
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("jg+HjPT1Iy86LLWmFjJHk87PV8xfLVERQY2ROdBli/vLKLSmhoAzcF1yiuE4/jnHbLM9rA1PaP5uMIUwmpedTA==", Convert.ToBase64String(output));
        }
    }
}
