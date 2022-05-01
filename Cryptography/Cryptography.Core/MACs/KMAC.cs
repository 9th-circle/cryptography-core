using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.Core.MACs
{
    class KMAC : Interfaces.IMAC
    {
        IHash hash;
        public KMAC(IHash hash)
        {
            this.hash = hash;
        }
        public byte[] generate(byte[] input, byte[] key)
        {
            //todo: actually implement KMAC
            var m = new MemoryStream();
            var w = new BinaryWriter(m);
            w.Write(key);
            w.Write(input);
            return hash.hash(m.ToArray());
        }
        public string primitiveName => "MAC-" + hash.primitiveName;
        public string primitiveVariation => null;
        public string implementationName => "Cryptography.Core";
    }
}
