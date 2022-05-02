using System.Security.Cryptography;
using Cryptography.Interfaces;

namespace Cryptography.SystemCryptography
{
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
    }
}