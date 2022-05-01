﻿namespace Cryptography.LibSodium
{
    class SodiumSHA512 : Interfaces.IHash
    {
        public byte[] hash(byte[] input)
        {
            return Sodium.CryptoHash.Sha512(input);
        }
        public string primitiveName => "SHA512";
        public string primitiveVariation => null;
        public string implementationName => "LibSodium";
    }
}