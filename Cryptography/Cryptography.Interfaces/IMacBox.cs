namespace Cryptography.Interfaces
{
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