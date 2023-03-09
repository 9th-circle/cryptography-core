#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;
using Audit.Interfaces.Annotations.SecurityConcern;
using Audit.Interfaces.Annotations.SecurityCritical;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of MD5.
    /// </summary>
    [BrokenCipherSecurityConcern]
    [SecurityCriticalThatThisIsNotUsed]
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
        public string primitiveID => "MD5";
    }
}
#endif