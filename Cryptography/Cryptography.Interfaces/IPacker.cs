using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    /// <summary>
    /// Interface to a class that packs/unpacks data into a byte array.
    /// </summary>
    public interface IPacker
    {
        void clear();
        void load(byte[] data);
        void pack(byte[] data);
        byte[] unPack();
        byte[] getOutput();
    }
}
