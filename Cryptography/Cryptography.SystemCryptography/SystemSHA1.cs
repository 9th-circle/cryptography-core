using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.SystemCryptography
{
    class SystemSHA1 : Interfaces.IHash
    {
        SHA1Managed sha = new SHA1Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-1";
        public string primitiveVariation => null;
        public string implementationName => "System.Cryptography";
    }
}
