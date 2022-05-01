using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.LibSodium;
using Cryptography.SystemCryptography;
using Xunit;

namespace Cryptography.Tests
{
    public class HashCrossCheck
    {
        [Theory]
        [InlineData("test data")]
        [InlineData("some other data")]
        [InlineData("11111111111222222222222222222233333333333333344444444444445555555555555")]
        public void sha256(string testData)
        {
            var a = new SodiumSHA256();
            var b = new SystemSHA256();
            
            doCrossCheck(a, b, Encoding.UTF8.GetBytes(testData));
        }
        [Theory]
        [InlineData("test data")]
        [InlineData("some other data")]
        [InlineData("11111111111222222222222222222233333333333333344444444444445555555555555")]
        public void sha512(string testData)
        {
            var a = new SodiumSHA512();
            var b = new SystemSHA512();

            doCrossCheck(a, b, Encoding.UTF8.GetBytes(testData));
        }
        [Theory]
        [InlineData("test data")]
        [InlineData("some other data")]
        [InlineData("11111111111222222222222222222233333333333333344444444444445555555555555")]
        public void sha512cryptohash(string testData)
        {
            var a = new SodiumSHA512();
            var b = new SodiumCryptoHash();

            doCrossCheck(a, b, Encoding.UTF8.GetBytes(testData));
        }
        [Theory]
        [InlineData("test data")]
        [InlineData("some other data")]
        [InlineData("11111111111222222222222222222233333333333333344444444444445555555555555")]
        public void notEqual(string testData)
        {
            var a = new SodiumSHA512();
            var b = new SodiumSHA256();

            doNotEqual(a, b, Encoding.UTF8.GetBytes(testData));
        }
        void doNotEqual(Interfaces.IHash a, Interfaces.IHash b, byte[] data)
        {
            Assert.NotEqual(a.hash(data), b.hash(data));
        }
        void doCrossCheck(Interfaces.IHash a, Interfaces.IHash b, byte[] data)
        {
            Assert.Equal(a.hash(data), b.hash(data));
        }
    }
}
