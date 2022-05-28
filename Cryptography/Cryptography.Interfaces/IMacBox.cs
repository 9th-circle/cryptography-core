namespace Cryptography.Interfaces
{
    /// <summary>
    /// A construction where you can share encrypted + authenticated data with someone you have decided on a shared authentication key for,
    /// but have exchanged public keys for the encryption of the actual data.
    /// </summary>
    public interface IMacBox : IBox
    {
        (byte[] senderKey, byte[] receiverKey) generateKeyPair();
        byte[] generateNonce();
        byte[] encrypt(byte[] data, byte[] senderKey, byte[] nonce);
        byte[] decrypt(byte[] data, byte[] receiverKey, byte[] nonce);
        string underlyingSymmetricPrimitiveName { get; }
        string underlyingAsymmetricPrimitiveName { get; }
        string underlyingMACPrimitiveName { get; }
    }
}