using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces.Constructions
{
    /// <summary>
    /// A construction for encrypting + authenticating data where both parties have agreed on a single shared key for
    /// both authentication and encryption.
    /// </summary>
    public interface ISymmetricBox : IBox
    {
        /// <summary> Generate a shared secret key. </summary>
        byte[] generateKey();
        
        /// <summary> Given the shared secret key, encrypt some data. </summary>
        byte[] encrypt(byte[] data, byte[] key);

        /// <summary> Given the shared secret key, decrypt some data. </summary>
        byte[] decrypt(byte[] data, byte[] key);


        /// <summary> The name of the symmetric (stream/block) cipher this construction uses. </summary>
        string underlyingSymmetricPrimitiveName { get; }

        /// <summary> The name of the authentication (MAC) primitive this construction uses. </summary>
        string underlyingMACPrimitiveName { get; }
    }
}
