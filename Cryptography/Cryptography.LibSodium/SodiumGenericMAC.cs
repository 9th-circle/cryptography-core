using System.Collections.Generic;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium GenericHash implementation of BLAKE2b.
    /// </summary>
    [SecurityCritical]
    public class SodiumGenericMAC : IMAC
    {
        public byte[] generate(byte[] input, byte[] key)
        {
            List<byte> newKey = new List<byte>();
            newKey.AddRange(key);
            while(newKey.Count < 16)
                newKey.Add(0);
            return Sodium.GenericHash.Hash(input, newKey.ToArray(), 64);
        }

        public string primitiveName => "BLAKE2b";
        public string primitiveVariation => "CryptoGeneticHash";
        public string implementationName => "LibSodium";
        public string primitiveID => "BLAKE2b";
    }
}