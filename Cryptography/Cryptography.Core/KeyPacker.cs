using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    class KeyPacker : IKeyPacker
    {
        public KeyPacker()
        {
        }
        public KeyPacker(byte[] data)
        {
        }
        public void packKey(byte[] data)
        {

        }
        public byte[] unPackKey()
        {
            return null;
        }
        public byte[] getOutput()
        {
            return null;
        }
    }
}
