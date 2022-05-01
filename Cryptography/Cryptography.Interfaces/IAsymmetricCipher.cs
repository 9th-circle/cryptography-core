namespace Cryptography.Interfaces
{
    public interface IAsymmetricCipher : IPrimitive
    {
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        byte[] encrypt(byte[] data, byte[] publicKey);
        byte[] decrypt(byte[] data, byte[] privateKey);
    }
}