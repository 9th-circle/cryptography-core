using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces.Primitives;
using Cryptography.Interfaces.Constructions;

namespace Cryptography.Interfaces.Constructions
{
    /// <summary>
    /// Construction for taking many small hashes and combining them into a tree with a single value at the top.
    /// </summary>
    public interface IHashTree : IPrimitive
    {
        /// <summary> Take a piece of data and generate a fingerprint for it at that tier of the tree. </summary>
        byte[] hashChunk(byte[] leafData, long tier);
    }
}
