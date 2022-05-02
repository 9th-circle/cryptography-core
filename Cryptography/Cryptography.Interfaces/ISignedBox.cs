using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface ISignedBox : IBox
    {
        (byte[] publicKey, byte[] privateKey) generateKeyPair();
        byte[] generateSharedKey();
        byte[] encrypt(byte[] data, byte[] sharedKey, byte[] privateKey);
        byte[] decrypt(byte[] data, byte[] sharedKey, byte[] publicKey);
        string underlyingSymmetricPrimitiveName { get; }
        string underlyingSignaturePrimitiveName { get; }
    }
}
