using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of MD5.
    /// This cipher is completely broken. Do not use it for anything.
    /// </summary>
    public class SystemMD5 : IHash
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        public byte[] hash(byte[] input)
        {
            return md5.ComputeHash(input);
        }
        public string primitiveName => "MD5";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
    }
}
