using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    public interface ISymmetricBox
    {
        byte[] generateKey();
        byte[] encrypt(byte[] data, byte[] key);
        byte[] decrypt(byte[] data, byte[] key);


        string underlyingSymmetricPrimitiveName { get; }
        string underlyingMACPrimitiveName { get; }
    }
}
