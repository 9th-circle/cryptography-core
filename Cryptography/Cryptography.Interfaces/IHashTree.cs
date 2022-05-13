using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface IHashTree : IPrimitive
    {
        byte[] hashChunk(byte[] leafData, long tier);
    }
}
