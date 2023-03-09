#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
using System.IO;
using System.Security.Cryptography;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of AES.
    /// This version operates in CBC mode.
    /// </summary>
    [Audit.Interfaces.Annotations.SecurityConcern(description = "This configuration can result in the creation of a padding oracle (even when suppressing errors, just with timing alone).")]
    [Audit.Interfaces.Annotations.SecurityConcern(description = "This implementation can leak timing secrets.", conditions = "On systems where AES-NI custom instructions are not available.")]
    public class SystemAES_CBC : IBlockCipher
    {
        public byte[] generateKey()
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] output = new byte[256 / 8];
            rng.GetBytes(output);
            return output;
        }
        public byte[] generateNonce()
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] output = new byte[128 / 8];
            rng.GetBytes(output);
            return output;
        }
        public byte[] encrypt(byte[] data, byte[] key, byte[] nonce)
        {
            try
            {
                var output = new MemoryStream();
                var aes = new AesManaged();
                aes.Mode = CipherMode.CBC;
                var e = aes.CreateEncryptor(key,nonce);

                using (CryptoStream cs = new CryptoStream(output, e, CryptoStreamMode.Write))
                {
                    using (BinaryWriter sw = new BinaryWriter(cs))
                        sw.Write(data);
                    cs.Flush();
                    return output.ToArray();
                }
            }
            catch
            {
                return null;    //do not propagate any clues about why it failed
            }
        }
        public byte[] decrypt(byte[] data, byte[] key, byte[] nonce)
        {
            try
            {
                var input = new MemoryStream(data);
                var aes = new AesManaged();
                aes.Mode = CipherMode.CBC;
                var d = aes.CreateDecryptor(key, nonce);

                using (CryptoStream cs = new CryptoStream(input, d, CryptoStreamMode.Read))
                {
                    using (var output = new MemoryStream())
                    {
                        cs.CopyTo(output);
                        return output.ToArray();
                    }
                }
            }
            catch
            {
                return null;    //do not propagate any clues about why it failed
            }
        }

        public BlockCipherMode mode => BlockCipherMode.CBC;
        public string primitiveName => "AES";
        public string primitiveVariation => "KeySize=256";
        public string implementationName => "System.Security.Cryptography";
        public string primitiveID => "AES-256-CBC";
    }
}
#endif