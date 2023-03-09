using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces;

namespace Cryptography.Core
{
    /// <summary>
    /// Simple implementation of a data packer that prefixes each chunk of data with its length.
    /// This packer's output is distinguishable from random even if the input data is not.
    /// </summary>
    [SecurityCritical]
    public class PrefixPacker : IPacker
    {
        List<byte> contents = new List<byte>();
        public void clear()
        {
            lock (contents)
                contents.Clear();
        }
        public void load(byte[] data)
        {
            lock (contents)
            {
                contents.Clear();
                contents.AddRange(data);
            }
        }
        public void pack(byte[] data)
        {
            lock (contents)
            {
                contents.AddRange(BitConverter.GetBytes(data.Length));
                contents.AddRange(data);
            }
        }
        //todo: handle invalid contents -- negative or excessively large lengths, stuff like that
        public byte[] unPack()
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
