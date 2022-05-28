﻿using System.Security.Cryptography;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of SHA512.
    /// Note that this cipher provides no protection against length extension attacks.
    /// </summary>
    public class SystemSHA512 : IHash
    {
        SHA512Managed sha = new SHA512Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-512";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
        public string primitiveID => "SHA-512";
    }
}