using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    /// <summary>
    /// A construction that allows you to send/receive encrypted & authenticated data with someone you've exchanged public keys with.
    /// </summary>
    public interface IAsymmetricBox : IBox
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        byte[] generateNonce();
        byte[] encrypt(byte[] data, byte[] senderPrivateKey, byte[] receiverPublicKey, byte[] nonce);
        byte[] decrypt(byte[] data, byte[] receiverPrivateKey, byte[] senderPublicKey, byte[] nonce);
        string underlyingSymmetricPrimitiveName { get; }
        string underlyingAsymmetricPrimitiveName { get; }
        string underlyingSignaturePrimitiveName { get; }
    }
}
