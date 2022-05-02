using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface IAsymmetricBox
    {
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        byte[] generateNonce();
        byte[] encrypt(byte[] data, byte[] secretKey, byte[] publicKey, byte[] nonce);
        byte[] decrypt(byte[] data, byte[] secretKey, byte[] publicKey, byte[] nonce);
        string underlyingSymmetricPrimitiveName { get; }
        string underlyingAsymmetricPrimitiveName { get; }
        string underlyingSignaturePrimitiveName { get; }
    }
}
