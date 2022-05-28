using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    /// <summary>
    /// Construction for taking many small hashes and combining them into a tree with a single value at the top.
    /// </summary>
    public interface IHashTree : IPrimitive
    {
        byte[] hashChunk(byte[] leafData, long tier);
    }
}
