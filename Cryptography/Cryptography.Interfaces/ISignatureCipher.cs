namespace Cryptography.Interfaces
{
    /// <summary>
    /// Interface to a cryptographic primitive that allows asymmetric signatures.
    /// </summary>
    public interface ISignatureCipher : IPrimitive
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        
        /// <summary> Sign a piece of data with a private key. </summary>
        byte[] sign(byte[] data, byte[] privateKey);

        /// <summary> Check whether a signature is valid, given the provided data and a public key. </summary>
        bool signatureIsValid(byte[] data, byte[] publicKey, byte[] signature);
    }
}