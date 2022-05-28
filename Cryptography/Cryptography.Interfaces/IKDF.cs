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
        byte[] generateSalt();
        byte[] generate(byte[] input, byte[] salt);
        bool valid(byte[] data, byte[] hash);
    }
}
