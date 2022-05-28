using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    /// <summary>
    /// A primitive that can take a chunk of data and generate a unique (short) fingerprint for it.
    /// </summary>
    public interface IHash : IPrimitive
    {
        /// <summary> Process a piece of data and generate a fingerprint for it. </summary>
        byte[] hash(byte[] input);
    }
}
