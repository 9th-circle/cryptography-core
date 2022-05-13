using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.Core.HashTrees
{
    class SimpleHashTree : IHashTree
    {
        IHash inner;
        public SimpleHashTree(IHash inner)
        {
            this.inner = inner;
        }
        public byte[] hashChunk(byte[] leafData, long tier)
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(tier));
            data.AddRange(BitConverter.GetBytes(leafData.LongLength));
            data.AddRange(leafData);
            return inner.hash(data.ToArray());
        }
        public string primitiveName => inner.primitiveName;
        public string primitiveVariation => inner.primitiveVariation;
        public string implementationName => inner.implementationName;
    }
}