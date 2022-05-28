using Cryptography.LibSodium;
using System;
using System.Text;
using Xunit;

namespace Cryptography.Tests
{
    public class SodiumHash
    {
        [Fact]
        public void generic()
        {
            var hash = new SodiumGenericMAC();
            var output = hash.generate(Encoding.UTF8.GetBytes("some slightly longer input"), Encoding.UTF8.GetBytes("passwordpassword"));
            Assert.Equal("cK2fD2HjRSlBxh0zALtECWq39e7XZq72DmY=", Convert.ToBase64String(output));
        }
        [Fact]
        public void argonTest()
        {
            SodiumArgonKDF kdf = new SodiumArgonKDF();
            kdf.generateSalt(); //we will not use this one
            var salt = Convert.FromBase64String("CcqbVMSAYFm0KweQMSDNKA==");    //here's one we prepared earlier
            var input = Encoding.UTF8.GetBytes("password goes here");
            var output = kdf.generate(input, salt);

            Assert.Equal("Oa9HCmzfbZSBDlLRR2latQ==",Convert.ToBase64String(output));
        }
        [Fact]
        public void scryptTest()
        {
            SodiumScryptKDF kdf = new SodiumScryptKDF();
            kdf.generateSalt(); //we will not use this one
            var salt = Convert.FromBase64String("isE1iLU/b3kBRF9swdEO7NysWBzDvf9lOqA3jer48lo=");    //here's one we prepared earlier
            var input = Encoding.UTF8.GetBytes("password goes here");
            var output = kdf.generate(input, salt);

            Assert.Equal("uXffLjD7fyhcWmoR26+5ja/wHKk1w9l7b0Wzth/Xk+Y=", Convert.ToBase64String(output));
        }
        [Fact]
        public void sha256()
        {
            var hash = new SodiumSHA256();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("K+NbxnHckS5/VA8OWi6RXvakpNvSraW6nB0rEXv8kHw=", Convert.ToBase64String(output));
        }
        [Fact]
        public void sha512()
        {
            var hash = new SodiumSHA512();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("nUxrk0FgDMzvkfErD2SgxXZNJ5kCEkAD6ATFPl3/XVBxQOWcMYB0RT2dPv0zPVg/QSozg6SGmbpsIbd8hj4WVQ==", Convert.ToBase64String(output));
        }
        [Fact]
        public void cryptoHash()
        {
            var hash = new SodiumCryptoHash();
            var output = hash.hash(Encoding.UTF8.GetBytes("some input"));
            Assert.Equal("nUxrk0FgDMzvkfErD2SgxXZNJ5kCEkAD6ATFPl3/XVBxQOWcMYB0RT2dPv0zPVg/QSozg6SGmbpsIbd8hj4WVQ==", Convert.ToBase64String(output));
        }

    }
}