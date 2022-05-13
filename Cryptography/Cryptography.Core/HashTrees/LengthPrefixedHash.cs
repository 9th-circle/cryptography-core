using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.Core.HashTrees
{
    class LengthPrefixedHash : IHash
    {
        IHash inner;
        public LengthPrefixedHash(IHash inner)
        {
            this.inner = inner;
        }
        public byte[] hash(byte[] input)
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(input.Length));
            data.AddRange(input);
            return inner.hash(data.ToArray());
        }
        public string primitiveName => inner.primitiveName;
        public string primitiveVariation => inner.primitiveVariation;
        public string implementationName => inner.implementationName;
    }
}
