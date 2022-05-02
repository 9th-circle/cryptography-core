using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.Core.MACs
{
    class ConcatMAC : Interfaces.IMAC
    {
        IHash hash;
        public ConcatMAC(IHash hash)
        {
            this.hash = hash;
        }
        public byte[] generate(byte[] input, byte[] key)
        {
            var m = new MemoryStream();
            var w = new BinaryWriter(m);
            w.Write(key.Length);
            w.Write(input.Length);
            w.Write(new byte[8]);
            w.Write(key);
            w.Write(input);
            return hash.hash(m.ToArray());
        }
        public string primitiveName => "ConcatMAC-" + hash.primitiveName;
        public string primitiveVariation => null;
        public string implementationName => "Cryptography.Core";
    }
}
