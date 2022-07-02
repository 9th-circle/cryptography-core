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
#if DEBUG
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
#endif
        [Fact]
        public void sha384()
        {
            var hash = new SystemSHA384();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("dNTLg4v2FoTaNnXn115kQ2oKbExDigTDR55EGhmL0sGV0u0nT1CWSsRuFdZJKi2N", Convert.ToBase64String(output));
        }
#if DEBUG
        [Fact]
        public void sha512()
        {
            var hash = new SystemSHA512();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("nUxrk0FgDMzvkfErD2SgxXZNJ5kCEkAD6ATFPl3/XVBxQOWcMYB0RT2dPv0zPVg/QSozg6SGmbpsIbd8hj4WVQ==", Convert.ToBase64String(output));
        }
#endif
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
#if DEBUG
        [Fact]
        public void lengthPrefixed_sha512()
        {
            var hash = new Core.LengthPrefixedHash(new SystemSHA512());
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("CgAAAJ1Ma5NBYAzM75HxKw9koMV2TSeZAhJAA+gExT5d/11QcUDlnDGAdEU9nT79Mz1YP0EqM4Okhpm6bCG3fIY+FlU=", Convert.ToBase64String(output));
        }
        [Fact]
        public void testHashTree()
        {
            var hash = new Core.LengthPrefixedHash(new SystemSHA512());
            var tree = new Core.HashTrees.SimpleHashTree(hash);
            var firstLeaf = tree.hashChunk(Encoding.UTF8.GetBytes("some input"),0);
            var secondLeaf = tree.hashChunk(Encoding.UTF8.GetBytes("blah blah"), 0);
            List<byte> combined = new List<byte>();
            combined.AddRange(firstLeaf);
            combined.AddRange(secondLeaf);
            var branch = tree.hashChunk(combined.ToArray(), 1);

            Assert.Equal("mAAAAHPB/YEj2Zt7BUIgpqkjYA4HY4Zl2MrkD10uCUuvGB2Fnoc8w8E+hjIP48fWcW7GR9T5R5F4Gv8EpqwBxwmg1Iw=", Convert.ToBase64String(branch));
        }
#endif
    }
}
