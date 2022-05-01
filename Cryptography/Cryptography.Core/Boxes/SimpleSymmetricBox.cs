using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleSymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        public SimpleSymmetricBox(IMAC mac, ISymmetricCipher symmetric)
        {
            this.mac = mac;
            this.symmetric = symmetric;
        }
    }
}