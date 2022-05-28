using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public enum BlockCipherMode
    {
        /// <summary> Converts this block cipher into a stream cipher. Recommended mode. </summary>
        CTR,

        /// <summary> A mode of encryption that is mostly fine but can leak timing secrets or provide a padding oracle.</summary>
        CBC,

        /// <summary> An almost completely broken mode of encryption that should never be used except for some narrow edge cases. </summary>
        ECB,

        /// <summary> A mode that rolls authentication into a block cipher mode, but is very sensitive to key/IV reuse as a result. </summary>
        GCM,

        /// <summary> A mode that rolls authentication into a block cipher mode, but is very sensitive to key/IV reuse as a result. </summary>
        CCM,

        /// <summary> A mode that rolls authentication into a block cipher mode, and offers some key/IV reuse resistance. </summary>
        SIV,

        /// <summary> A mode that rolls authentication into a block cipher mode, and a little more key/IV reuse resistance than SIV. </summary>
        GCM_SIV,
        
        /// <summary> A mode of encryption that is mostly fine but can leak timing secrets or provide a padding oracle.</summary>
        PCBC,

        /// <summary> A mode of encryption that is mostly fine but can leak timing secrets or provide a padding oracle.</summary>
        CFB,

        /// <summary> A mode of encryption that is mostly fine but can leak timing secrets or provide a padding oracle.</summary>
        OFB
    }

    /// <summary>
    /// A cryptographic primitive that operates on a fixed size block and must use a chaining mode to encrypt arbitrary-length data.
    /// </summary>
    public interface IBlockCipher : ISymmetricCipher
    {
        /// <summary> Which block cipher mode the cipher is set to use. The correct answer is CTR. </summary>
        BlockCipherMode mode { get; }
    }
}
