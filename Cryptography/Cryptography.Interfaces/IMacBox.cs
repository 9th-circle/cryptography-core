namespace Cryptography.Interfaces
{
    /// <summary>
    /// A construction where you can share encrypted + authenticated data with someone you have decided on a shared authentication key for,
    /// but have exchanged public keys for the encryption of the actual data.
    /// </summary>
    public interface IMacBox : IBox
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] senderKey, byte[] receiverKey) generateKeyPair();
        byte[] generateNonce();
        byte[] encrypt(byte[] data, byte[] senderKey, byte[] nonce);
        byte[] decrypt(byte[] data, byte[] receiverKey, byte[] nonce);

        /// <summary> The name of the symmetric (stream/block) cipher this construction uses. </summary>
        string underlyingSymmetricPrimitiveName { get; }
        /// <summary> The name of the asymmetric (public key) cipher this construction uses. </summary>
        string underlyingAsymmetricPrimitiveName { get; }
        string underlyingMACPrimitiveName { get; }
    }
}