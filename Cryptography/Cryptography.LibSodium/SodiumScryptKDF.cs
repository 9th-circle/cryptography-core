﻿using Audit.Interfaces.Annotations;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium GenericHash implementation of scrypt password hash/KDF.
    /// </summary>
    [SecurityCritical]
    public class SodiumScryptKDF : IKDF
    {
        public byte[] generateSalt()
        {
            return Sodium.PasswordHash.ScryptGenerateSalt();
        }
        public byte[] generate(byte[] input, byte[] salt)
        {
            return Sodium.PasswordHash.ScryptHashBinary(input, salt);
        }
        public string primitiveName => "scrypt";
        public string primitiveVariation => "outputLength=32";
        public string implementationName => "LibSodium";
        public string primitiveID => "scrypt-output=32";
    }
}