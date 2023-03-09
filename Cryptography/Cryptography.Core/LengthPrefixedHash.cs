#if DEBUG       //This construction has not been validated/examined enough for production use.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;
using Cryptography.Interfaces.Constructions;

namespace Cryptography.Core
{
    /// <summary>
    /// Construction around a hash that includes the input data length as part of the output. Intended to defend against length extension attacks.
    /// </summary>
    [Audit.Interfaces.Annotations.SecurityConcern(description = "This construction has not been audited and is likely to be insecure.")]
    public class LengthPrefixedHash : IHash
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
            data.AddRange(inner.hash(input));
            return (data.ToArray());
        }
        public string primitiveName => inner.primitiveName;
        public string primitiveVariation => inner.primitiveVariation;
        public string implementationName => inner.implementationName;



        public string primitiveID => "LPR-" + inner.primitiveID;
    }
}
#endif