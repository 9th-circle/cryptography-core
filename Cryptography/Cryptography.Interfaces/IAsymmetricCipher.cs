namespace Cryptography.Interfaces
{
    public interface IAsymmetricCipher : IPrimitive
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        byte[] encrypt(byte[] data, byte[] publicKey);
        byte[] decrypt(byte[] data, byte[] privateKey);
    }
}