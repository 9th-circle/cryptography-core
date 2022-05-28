namespace Cryptography.Interfaces.Primitives
{
    /// <summary>
    /// Parent interface for either a stream cipher or block cipher.
    /// </summary>
    public interface ISymmetricCipher : IPrimitive
    {
        /// <summary> Generate a shared secret key. </summary>
        byte[] generateKey();

        /// <summary> Generate a one-time nonce. </summary>
        byte[] generateNonce();

        /// <summary> Given a shared secret key and a one-time nonce, encrypt some data. </summary>
        byte[] encrypt(byte[] data, byte[] key, byte[] nonce);

        /// <summary> Given a shared secret key and a one-time nonce, decrypt some data. </summary>
        byte[] decrypt(byte[] data, byte[] key, byte[] nonce);
    }
}