namespace Cryptography.Interfaces.Primitives
{
    public interface IAsymmetricCipher : IPrimitive
    {
        /// <summary> Generates a public and private key pair. </summary>
        (byte[] publicKey, byte[] privateKey) generateKeyPair();

        /// <summary> Encrypt a piece of data using someone's public key, so that it can be decrypted by them using their private key. </summary>
        byte[] encrypt(byte[] data, byte[] publicKey);

        /// <summary> Decrypt a piece of data using our private key, that was encrypted for our public key. </summary>
        byte[] decrypt(byte[] data, byte[] privateKey);
    }
}