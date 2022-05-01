namespace Cryptography.Interfaces
{
    public interface ISymmetricCipher : IPrimitive
    {
        byte[] generateKey();
        byte[] generateNonce();
        byte[] encrypt(byte[] data, byte[] key, byte[] nonce);
        byte[] decrypt(byte[] data, byte[] key, byte[] nonce);
    }
}