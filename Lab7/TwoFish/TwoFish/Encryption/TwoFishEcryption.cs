﻿using System;
using System.IO;

using HOP.Encryption.API;

using ManyMonkeys.Cryptography;
using System.Security.Cryptography;

using System.Runtime.CompilerServices;
using HOP.Config.API;

[assembly: InternalsVisibleTo("EncryptionTest")]

namespace HOP.Encryption
{
    class TwoFishEncryption : IEncryption
    {
        private byte[] key;

        public TwoFishEncryption(IConfiguration config)
        {
            key = File.ReadAllBytes(config.GetKeyFilePath());
        }

        // TODO: next 2 functions should be replaced by Encoding variants.
        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars).Replace("\0", string.Empty);
        }

        public string Encrypt(string str)
        {
            Twofish fish = new Twofish();

            fish.Mode = CipherMode.ECB;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            byte[] dummy = { };

            //create Twofish Encryptor from this instance
            ICryptoTransform encrypt = fish.CreateEncryptor(key, dummy); // we use the plainText as the IV as in ECB mode the IV is not used

            //Create Crypto Stream that transforms file stream using twofish encryption
            CryptoStream cryptostream = new CryptoStream(ms, encrypt, CryptoStreamMode.Write);

            byte[] plainText = GetBytes(str);

            //write out Twofish encrypted stream
            cryptostream.Write(plainText, 0, plainText.Length);

            cryptostream.Close();

            byte[] bytOut = ms.ToArray();

            return GetString(bytOut);
        }

        public string Decrypt(string encrypted_str)
        {
            Twofish fish = new Twofish();

            fish.Mode = CipherMode.ECB;

            byte[] plainText = { };

            //create Twofish Decryptor from our twofish instance
            ICryptoTransform decrypt = fish.CreateDecryptor(key, plainText);

            System.IO.MemoryStream msD = new System.IO.MemoryStream();

            //create crypto stream set to read and do a Twofish decryption transform on incoming bytes
            CryptoStream cryptostreamDecr = new CryptoStream(msD, decrypt, CryptoStreamMode.Write);

            byte[] bytOut = GetBytes(encrypted_str);

            //write out Twofish encrypted stream
            cryptostreamDecr.Write(bytOut, 0, bytOut.Length);

            cryptostreamDecr.Close();

            byte[] bytOutD = msD.GetBuffer();

            return GetString(bytOutD);
        }

        public byte[] Encrypt(byte[] file)
        {
            Twofish fish = new Twofish();

            fish.Mode = CipherMode.ECB;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            byte[] dummy = { };

            //create Twofish Encryptor from this instance
            ICryptoTransform encrypt = fish.CreateEncryptor(key, dummy); // we use the plainText as the IV as in ECB mode the IV is not used

            //Create Crypto Stream that transforms file stream using twofish encryption
            CryptoStream cryptostream = new CryptoStream(ms, encrypt, CryptoStreamMode.Write);

            //write out Twofish encrypted stream
            cryptostream.Write(file, 0, file.Length);

            cryptostream.Close();

            return ms.ToArray();
        }

        public byte[] Decrypt(byte[] file)
        {
            Twofish fish = new Twofish();

            fish.Mode = CipherMode.ECB;

            byte[] dummy = { };

            //create Twofish Decryptor from our twofish instance
            ICryptoTransform decrypt = fish.CreateDecryptor(key, dummy);

            System.IO.MemoryStream msD = new System.IO.MemoryStream();

            //create crypto stream set to read and do a Twofish decryption transform on incoming bytes
            CryptoStream cryptostreamDecr = new CryptoStream(msD, decrypt, CryptoStreamMode.Write);

            //write out Twofish encrypted stream
            cryptostreamDecr.Write(file, 0, file.Length);

            cryptostreamDecr.Close();

            byte[] buf = msD.GetBuffer();

            // TODO: It might be pretty dangerous to cut on the size of the input buffer
            // because of the padding some bytes might be added. However these bytes will 
            // be only zeros (External.Twofish uses Padding.Zero) so zeros should be OK.
            Array.Resize(ref buf, file.Length);
            // We can not remove any other padding bytes because we can not distinuish between
            // bytes added by the crypto algo and bytes belonging to the original unecrtypted file.

            return buf;
        }
    }
}