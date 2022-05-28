namespace Cryptography.Interfaces
{
    /// <summary>
    /// Parent interface for either a stream cipher or block cipher.
    /// </summary>
    public interface ISymmetricCipher : IPrimitive
    {
        byte[] generateKey();
        byte[] generateNonce();
        byte[] encrypt(byte[] data, byte[] key, byte[] nonce);
        byte[] decrypt(byte[] data, byte[] key, byte[] nonce);
    }
}