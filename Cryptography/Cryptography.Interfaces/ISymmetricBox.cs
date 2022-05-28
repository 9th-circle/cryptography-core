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


        string underlyingSymmetricPrimitiveName { get; }
        string underlyingMACPrimitiveName { get; }
    }
}
