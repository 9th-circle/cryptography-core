using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    /// <summary>
    /// A primitive that acts as a hash with a secret key. The main benefit of these primitives/constructions is resistance
    /// against length extension attacks.
    /// </summary>
    public interface IMAC : IPrimitive
    {
        byte[] generate(byte[] input, byte[] key);
    }
}
