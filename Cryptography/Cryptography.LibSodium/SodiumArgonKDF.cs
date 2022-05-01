using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.LibSodium
{
    class SodiumArgonKDF : IKDF
    {
        public byte[] generateSalt()
        {
            return Sodium.PasswordHash.ArgonGenerateSalt();
        }
        public byte[] generate(byte[] input, byte[] salt)
        {
            return Sodium.PasswordHash.ArgonHashBinary(input, salt);
        }
        public bool valid(byte[] data, byte[] hash)
        {
            return Sodium.PasswordHash.ArgonHashStringVerify(hash, data);
        }
        public string primitiveName => "Argon2";
        public string primitiveVariation => "i13 outputLength=16";
        public string implementationName => "LibSodium";
    }
}
