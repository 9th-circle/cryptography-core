using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium GenericHash implementation of BLAKE2b.
    /// </summary>
    public class SodiumGenericHash : IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.GenericHash.Hash(input, new byte[16], 64);
        }

        public string primitiveName => "BLAKE2b";
        public string primitiveVariation => "CryptoGeneticHash";
        public string implementationName => "LibSodium";
        public string primitiveID => "BLAKE2b";
    }
}
