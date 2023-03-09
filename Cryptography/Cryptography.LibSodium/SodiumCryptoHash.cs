#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
            //SHA-512 is considered secure against collision attacks, but not against length extension.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium CryptoHash implementation of SHA512.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    [SecurityCritical]
    public class SodiumCryptoHash : IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.CryptoHash.Hash(input);
        }
        public string primitiveName => "SHA-512";
        public string primitiveVariation => null;
        public string implementationName => "LibSodium";
        public string primitiveID => "SHA-512";
    }
}
#endif