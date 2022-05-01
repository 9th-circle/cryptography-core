using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface IKeyPacker
    {
        void load(byte[] data);
        void packKey(byte[] data);
        byte[] unPackKey();
        byte[] getOutput();
    }
}
