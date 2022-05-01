using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemRSA : Interfaces.IAsymmetricCipher
    {
        RSA rsa = new RSACryptoServiceProvider();
        
        public string primitiveName => "RSA";
        public string primitiveVariation => null;
        public string implementationName => "System.Cryptography";
    }
}