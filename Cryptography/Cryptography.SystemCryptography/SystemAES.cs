using Cryptography.Interfaces;

namespace Cryptography.SystemCryptography
{
    public class SystemAES : ISymmetricCipher
    {

        public string primitiveName => "AES";
        public string primitiveVariation => "KeySize=256";
        public string implementationName => "System.Security.Cryptography";
    }
}