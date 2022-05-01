using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.SystemCryptography
{
    public class SystemMD5 : Interfaces.IHash
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
