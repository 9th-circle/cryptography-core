﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;
using Cryptography.Interfaces.Constructions;

namespace Cryptography.Core.HashTrees
{
    /// <summary>
    /// Simple implementation of a Merkle tree that prefixes the tree tier number to the data.
    /// </summary>
    [SecurityConcern(description = "This construction has not been audited and is likely to be insecure.")]
    [SecurityCritical(description = "It is critical that you *don't* use this.")]
    public class SimpleHashTree : IHashTree
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
        public string primitiveID => "SHT-" + inner.primitiveID;
    }
}