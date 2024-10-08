﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;
using Sodium;

namespace Cryptography.LibSodium
{
    /// <summary>
    /// Link to the LibSodium GenericHash implementation of Argon2 password hash/KDF.
    /// </summary>
    [SecurityCritical]
    public class SodiumArgonKDF : IKDF
    {
        public byte[] generateSalt()
        {
            return PasswordHash.ArgonGenerateSalt();
        }
        public byte[] generate(byte[] input, byte[] salt)
        {
            try
            {
                return PasswordHash.ArgonHashBinary(input, salt, PasswordHash.StrengthArgon.Interactive, 16, PasswordHash.ArgonAlgorithm.Argon_2ID13);
            }
            catch
            {
                return null;
            }
        }
        public string primitiveName => "Argon2id";
        public string primitiveVariation => "outputLength=16";
        public string implementationName => "LibSodium";
        public string primitiveID => "Argon2id-interactive-outputLength=16-algorithm=2ID13";
    }
}
