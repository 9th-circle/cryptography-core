using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    /// <summary>
    /// A construction for encrypting + authenticating data where both parties have agreed on a single shared key for
    /// both authentication and encryption.
    /// </summary>
    public interface ISymmetricBox : IBox
    {
        byte[] generateKey();
        byte[] encrypt(byte[] data, byte[] key);
        byte[] decrypt(byte[] data, byte[] key);


        /// <summary> The name of the symmetric (stream/block) cipher this construction uses. </summary>
        string underlyingSymmetricPrimitiveName { get; }
        string underlyingMACPrimitiveName { get; }
    }
}
