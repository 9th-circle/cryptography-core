using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Interfaces.Constructions;
using Cryptography.Interfaces.Primitives;
using Cryptography.LibSodium;
using Cryptography.SystemCryptography;
using Microsoft.CSharp.RuntimeBinder;

namespace Cryptography
{
    public static class SafeCryptoFactory
    {
        static Injector.Core.FactoryBundle bundle = Injector.Core.Entry.createBundle();

        public static IAsymmetricBox createSodiumPublicKeyBox()
        {
            return bundle.factory.create<IAsymmetricBox>(typeof(SodiumPublicKeyBox));
        }
        public static ISymmetricBox createSodiumSecretKeyBox()
        {
            return bundle.factory.create<ISymmetricBox>(typeof(SodiumSecretBox));
        }
        public static IHash createSodiumGenericHash()
        {
            return bundle.factory.create<IHash>(typeof(SodiumGenericHash));
        }
        public static IMAC createSodiumGenericMac()
        {
            return bundle.factory.create<IMAC>(typeof(SodiumGenericMAC));
        }
        public static IKDF createSodiumArgonKDF()
        {
            return bundle.factory.create<IKDF>(typeof(SodiumArgonKDF));
        }
    }
}
