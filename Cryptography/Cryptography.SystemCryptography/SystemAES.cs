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
                var input = new MemoryStream(data);
                var output = new MemoryStream();
                var aes = new AesManaged();
                var e = aes.CreateEncryptor();

                using (CryptoStream cs = new CryptoStream(input, e, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                        sw.Write(data);
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
                var output = new MemoryStream();
                var aes = new AesManaged();
                var d = aes.CreateDecryptor();

                using (CryptoStream cs = new CryptoStream(input, d, CryptoStreamMode.Read))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                        sw.Write(data);
                    return output.ToArray();
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