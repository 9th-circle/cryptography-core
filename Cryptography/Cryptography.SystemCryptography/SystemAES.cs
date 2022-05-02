using System.IO;
using System.Security.Cryptography;
using Cryptography.Interfaces;

namespace Cryptography.SystemCryptography
{
    public class SystemAES : ISymmetricCipher
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
        public string primitiveName => "AES";
        public string primitiveVariation => "KeySize=256";
        public string implementationName => "System.Security.Cryptography";
    }
}