#if DEBUG   //If you are thinking about removing this line, you are probably about to make a major mistake.
using System.Security.Cryptography;
using Cryptography.Interfaces;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.SystemCryptography
{
    /// <summary>
    /// Link to the .NET System.Cryptography implementation of DSA.
    /// </summary>
    [Audit.Interfaces.Annotations.SecurityConcern(description = "This cipher is inherently sensitive to misuse and should be avoided for any purposes.")]
    public class SystemDSA : ISignatureCipher
    {
        public (byte[] publicKey, byte[] privateKey) generateKeyPair()
        {
            var dsa = new DSACryptoServiceProvider();
            dsa.PersistKeyInCsp = false;

            return (dsa.ExportSubjectPublicKeyInfo(), dsa.ExportPkcs8PrivateKey());
        }
        public byte[] sign(byte[] data, byte[] privateKey)
        {
            try
            {
                var dsa = new DSACryptoServiceProvider();
                dsa.PersistKeyInCsp = false;
                int read;
                dsa.ImportPkcs8PrivateKey(privateKey, out read);
                return dsa.SignData(data);
            }
            catch
            {
                return null;
            }
        }
        public bool signatureIsValid(byte[] data, byte[] publicKey, byte[] signature)
        {
            try
            {
                var dsa = new DSACryptoServiceProvider();
                dsa.PersistKeyInCsp = false;
                int read;
                dsa.ImportSubjectPublicKeyInfo(publicKey, out read);
                return dsa.VerifyData(data, signature);
            }
            catch
            {
                return false;
            }
        }
        public string primitiveName => "DSA";
        public string primitiveVariation => null;
        public string implementationName => "System.Security.Cryptography";
        public string primitiveID => "DSA";
    }
}
#endif