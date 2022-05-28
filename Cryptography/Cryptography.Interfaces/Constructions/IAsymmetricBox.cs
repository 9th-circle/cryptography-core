using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces.Constructions
{
    /// <summary>
    /// A construction that allows you to send/receive encrypted & authenticated data with someone you've exchanged public keys with.
    /// </summary>
    public interface IAsymmetricBox : IBox
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        byte[] generateNonce();

        /// <summary> Encrypt a piece of data for a desired recipient's public key, using our private key and a shared nonce </summary>
        byte[] encrypt(byte[] data, byte[] senderPrivateKey, byte[] receiverPublicKey, byte[] nonce);

        /// <summary> Decrypt a piece of data sent to our public key, using our private key and nonce. We also need to know the sender's public key. </summary>
        byte[] decrypt(byte[] data, byte[] receiverPrivateKey, byte[] senderPublicKey, byte[] nonce);
        
        /// <summary> The name of the symmetric (stream/block) cipher this construction uses. </summary>
        string underlyingSymmetricPrimitiveName { get; }

        /// <summary> The name of the asymmetric (public key) cipher this construction uses. </summary>
        string underlyingAsymmetricPrimitiveName { get; }


        /// <summary> The name of the asymmetric signature algorithm this construction uses. </summary>
        string underlyingSignaturePrimitiveName { get; }
    }
}
