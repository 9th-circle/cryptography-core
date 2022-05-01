using System.Security.Cryptography;

namespace Cryptography.SystemCryptography
{
    public class SystemRSA : Interfaces.IAsymmetricCipher
    {
        RSA rsa = new RSACryptoServiceProvider();

    }
}