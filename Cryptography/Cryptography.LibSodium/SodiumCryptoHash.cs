using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.LibSodium
{
    class SodiumCryptoHash : Interfaces.IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.CryptoHash.Hash(input);
        }
        public string primitiveName => "SHA-512";   //todo: check if this is correct
        public string primitiveVariation => null;
        public string implementationName => "LibSodium";
    }
}
