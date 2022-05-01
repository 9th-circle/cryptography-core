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
        List<byte> contents = new List<byte>();
        public void load(byte[] data)
        {
            lock (contents)
            {
                contents.Clear();
                contents.AddRange(data);
            }
        }
        public void packKey(byte[] data)
        {
            lock (contents)
            {
                contents.AddRange(BitConverter.GetBytes(data.Length));
                contents.AddRange(data);
            }
        }
        public byte[] unPackKey()
        {
            lock (contents)
            {
                byte[] length = contents.GetRange(0, 4).ToArray();
                contents.RemoveRange(0, 4);
                int lengthInt = BitConverter.ToInt32(length);
                byte[] output = contents.GetRange(0, lengthInt).ToArray();
                contents.RemoveRange(0, lengthInt);
                return output;
            }
        }
        public byte[] getOutput()
        { 
            lock (contents)
                return contents.ToArray();
        }
    }
}
