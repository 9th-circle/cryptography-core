﻿using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemSHA384 : Interfaces.IHash
    {
        SHA384Managed sha = new SHA384Managed();
        public byte[] hash(byte[] input)
        {
            return sha.ComputeHash(input);
        }
        public string primitiveName => "SHA-384";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
    }
}