﻿using System;
using System.Linq;
using Cryptography.Interfaces;

namespace Cryptography.Core.Boxes
{
    public class SimpleSymmetricBox : ISymmetricBox
    {
        IMAC mac;
        ISymmetricCipher symmetric;
        IPacker keyPacker;
        public SimpleSymmetricBox(IMAC mac, ISymmetricCipher symmetric, IPacker keyPacker)
        {
            this.mac = mac;
            this.symmetric = symmetric;
            this.keyPacker = keyPacker;
        }
        
        public byte[] generateKey()
        {
            lock (keyPacker)
            {
                keyPacker.clear();
                var symmetricKey = symmetric.generateKey();
                var symmetricNonce = symmetric.generateNonce();
                var macKey = symmetric.generateKey();

                keyPacker.pack(symmetricKey);
                keyPacker.pack(symmetricNonce);
                keyPacker.pack(macKey);

                return keyPacker.getOutput();
            }
        }
        public byte[] encrypt(byte[] data, byte[] key)
        {
            lock (keyPacker)
            {
                keyPacker.load(key);
                var symmetricKey = keyPacker.unPack();
                var nonce = keyPacker.unPack();
                var macKey = keyPacker.unPack();

                keyPacker.load(new byte[] { });

                var ciphertext = symmetric.encrypt(data, symmetricKey, nonce);
                var macOutput = mac.generate(ciphertext, macKey);
                keyPacker.pack(macOutput);
                keyPacker.pack(ciphertext);
                return keyPacker.getOutput();
            }
        }
        public byte[] decrypt(byte[] data, byte[] key)
        {
            lock (keyPacker)
            {
                keyPacker.load(key);
                var symmetricKey = keyPacker.unPack();
                var nonce = keyPacker.unPack();
                var macKey = keyPacker.unPack();

                keyPacker.load(data);
                var macValue = keyPacker.unPack();
                var cipherContents = keyPacker.unPack();

                if (!mac.generate(cipherContents, macKey).SequenceEqual(macValue))
                    return null;

                return symmetric.decrypt(cipherContents, symmetricKey, nonce);
            }
        }
        
        public string underlyingSymmetricPrimitiveName => symmetric.primitiveName;
        public string underlyingMACPrimitiveName => mac.primitiveName;
    }
}