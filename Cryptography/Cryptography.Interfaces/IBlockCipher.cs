using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public enum BlockCipherMode
    {
        CTR,
        CBC,
        ECB,
        GCM,
        CCM,
        SIV,
        GCM_SIV,
        PCBC,
        CFB,
        OFB
    }
    public interface IBlockCipher : ISymmetricCipher
    {
        BlockCipherMode mode { get; }
    }
}
