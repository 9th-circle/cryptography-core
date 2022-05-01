namespace Cryptography.Interfaces
{
    public interface ISignatureCipher : IPrimitive
    {
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        byte[] sign(byte[] data, byte[] privateKey);
        bool signatureIsValid(byte[] data, byte[] publicKey);
    }
}