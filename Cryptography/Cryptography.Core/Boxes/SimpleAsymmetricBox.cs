using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleAsymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        IAsymmetricCipher asymmetric;
        public SimpleAsymmetricBox(IMAC mac, ISymmetricCipher symmetric, IAsymmetricCipher asymmetric)
        {
            this.mac = mac;
            this.symmetric = symmetric;
            this.asymmetric = asymmetric;
        }
    }
}