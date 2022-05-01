using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface IAsymmetricBox
    {
        (byte[] publicKey, byte[] privateKey, byte[] shared) generateKeyPair();
        byte[] encrypt(byte[] data, byte[] publicKey, byte[] shared);
        byte[] decrypt(byte[] data, byte[] privateKey, byte[] shared);
        string underlyingSymmetricPrimitiveName { get; }
        string underlyingAsymmetricPrimitiveName { get; }
        string underlyingMACPrimitiveName { get; }
    }
}
