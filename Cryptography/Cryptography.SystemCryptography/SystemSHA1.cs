#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
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
    /// Link to the .NET System.Cryptography implementation of SHA1.
    /// This cipher is completely broken. Do not use it for anything.
    /// </summary>
    public class SystemSHA1 : IHash
    {
        SHA1Managed sha = new SHA1Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-1";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
        public string primitiveID => "SHA-1";
    }
}
#endif