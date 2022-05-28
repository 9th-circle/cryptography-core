using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    /// <summary>
    /// A primitive that allows you to generate an encryption key from a chunk of data.
    /// Generally used to turn passwords into encryption keys.
    /// Generally deliberately slow to prevent attackers bruteforcing them.
    /// </summary>
    public interface IKDF : IPrimitive
    {
        /// <summary> Generate a random non-secret piece of data that makes space-time tradeoff (rainbow tables etc) much less practical. </summary>
        byte[] generateSalt();

        /// <summary> Generate a key from the provided input and salt. Tne salt is copied into the output.</summary>
        byte[] generate(byte[] input, byte[] salt);

        /// <summary> Given a previously generated key, check if it matches the input provided. </summary>
        bool valid(byte[] input, byte[] hash);
    }
}
