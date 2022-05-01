using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface IKDF : IPrimitive
    {
        byte[] generateSalt();
        byte[] generate(byte[] input, byte[] salt);
        bool valid(byte[] data, byte[] hash);
    }
}
