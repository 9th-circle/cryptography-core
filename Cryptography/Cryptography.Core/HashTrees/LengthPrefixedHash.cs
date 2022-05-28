using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;

namespace Cryptography.Core.HashTrees
{
    /// <summary>
    /// Construction around a hash that includes the input data length as part of the output. Intended to defend against length extension attacks.
    /// This construction has not been extensively examined. Do not trust its security.
    /// </summary>
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
