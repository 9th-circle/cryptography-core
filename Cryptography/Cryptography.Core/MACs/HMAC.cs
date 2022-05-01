using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.Core.MACs
{
    class HMAC : Interfaces.IMAC
    {
        IHash hash;
        public HMAC(IHash hash)
        {
            this.hash = hash;
        }
        public byte[] generate(byte[] input, byte[] key)
        {
            throw new NotImplementedException();
            //todo: actually implement HMAC
            var m = new MemoryStream();
            var w = new BinaryWriter(m);
            w.Write(key);
            w.Write(input);
            return hash.hash(m.ToArray());
        }
        public string primitiveName => "HMAC-" + hash.primitiveName;
        public string primitiveVariation => null;
        public string implementationName => "Cryptography.Core";
    }
}
