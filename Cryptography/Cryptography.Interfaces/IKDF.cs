using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface IKDF : IPrimitive
    {
        byte[] generate(byte[] input);
    }
}
