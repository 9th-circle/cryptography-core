using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces.Constructions;
using Cryptography.Interfaces.Primitives;

namespace Cryptography.Interfaces
{
    public interface ICryptoFactory
    {
        public IAsymmetricBox createAsymmetricBox();
        public ISymmetricBox createSymmetricBox();
        public IHash createHash();
        public IMAC createMac();
        public IKDF createKDF();
    }
}
