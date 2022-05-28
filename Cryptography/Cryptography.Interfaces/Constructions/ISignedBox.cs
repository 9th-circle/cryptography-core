using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces.Constructions
{
    /// <summary>
    /// A construction that allows you to exchange encrypted + authenticated data with someone where you've agreed on a shared encryption key, but
    /// have exchanged public keys for authenticating the data.
    /// </summary>
    public interface ISignedBox : IBox
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] publicKey, byte[] privateKey) generateKeyPair();

        byte[] generateSharedKey();
        byte[] encrypt(byte[] data, byte[] sharedKey, byte[] privateKey);
        byte[] decrypt(byte[] data, byte[] sharedKey, byte[] publicKey);

        /// <summary> The name of the symmetric (stream/block) cipher this construction uses. </summary>
        string underlyingSymmetricPrimitiveName { get; }

        /// <summary> The name of the asymmetric signature algorithm this construction uses. </summary>
        string underlyingSignaturePrimitiveName { get; }
    }
}
