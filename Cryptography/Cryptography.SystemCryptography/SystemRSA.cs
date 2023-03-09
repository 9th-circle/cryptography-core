#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
using System.Security.Cryptography;
using Audit.Interfaces.Annotations;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of RSA.
    /// </summary>

    [SecurityCritical(description = "It is critical that you *don't* use this.")]
    [SecurityConcern(description = "This cipher is inherently sensitive to misuse and should be avoided for any purposes.")]
    public class SystemRSA : IAsymmetricCipher
    {
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var param = new CspParameters();
            param.Flags = CspProviderFlags.UseArchivableKey;

            var rsa = new RSACryptoServiceProvider(param);
            rsa.PersistKeyInCsp = false;

            return (rsa.ExportRSAPublicKey(), rsa.ExportRSAPrivateKey());
        }
        public byte[] encrypt(byte[] data, byte[] publicKey)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
                rsa.PersistKeyInCsp = false;
                int read;
                rsa.ImportRSAPublicKey(publicKey, out read);
                return rsa.Encrypt(data, true);
            }
            catch
            {
                return null;    //do not propagate any clues about why it failed
            }
        }
        public byte[] decrypt(byte[] data, byte[] privateKey)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
                rsa.PersistKeyInCsp = false;
                int read;
                rsa.ImportRSAPrivateKey(privateKey, out read);
                return rsa.Decrypt(data, true);
            }
            catch
            {
                return null;    //do not propagate any clues about why it failed
            }
        }
        public string primitiveName => "RSA";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
        public string primitiveID => "RSA";
    }
}
#endif