namespace Cryptography.Interfaces.Constructions
{
    /// <summary>
    /// A construction where you can share encrypted + authenticated data with someone you have decided on a shared authentication key for,
    /// but have exchanged public keys for the encryption of the actual data.
    /// </summary>
    public interface IMacBox : IBox
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] senderKey, byte[] receiverKey) generateKeyPair();
        /// <summary> Generate a shared one-time key. </summary>
        byte[] generateSharedKey();
        /// <summary> Given the sender's key and the shared authentication key, encrypt some data. </summary>
        byte[] encrypt(byte[] data, byte[] senderKey, byte[] sharedKey);
        /// <summary> Given the receiver's key and the shared authentication key, decrypt some data. </summary>
        byte[] decrypt(byte[] data, byte[] receiverKey, byte[] sharedKey);

        /// <summary> The name of the symmetric (stream/block) cipher this construction uses. </summary>
        string underlyingSymmetricPrimitiveName { get; }
        /// <summary> The name of the asymmetric (public key) cipher this construction uses. </summary>
        string underlyingAsymmetricPrimitiveName { get; }
        /// <summary> The name of the authentication (MAC) primitive this construction uses. </summary>
        string underlyingMACPrimitiveName { get; }
    }
}