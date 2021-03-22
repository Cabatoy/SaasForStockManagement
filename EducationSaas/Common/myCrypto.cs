using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public sealed class myCrypto
    {
        private static Lazy<myCrypto> lazy = new Lazy<myCrypto>(() => new myCrypto());

        public static myCrypto Instance { get { return lazy.Value; } }

        private myCrypto()
        {

        }

        public string SifreUygula(string TextVeri, string yardimciVeri)
        {
            return Encrypt(TextVeri, yardimciVeri);
        }

        public string SifreyiCoz(string TextVeri, string yardimciVeri)
        {
            return Decrypt(TextVeri, yardimciVeri);
        }

        private static string Decrypt(string cipherText, string Password)
        {
            byte[] cipherData = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            byte[] buffer2 = Decrypt(cipherData, bytes.GetBytes(0x20), bytes.GetBytes(0x10));
            return Encoding.Unicode.GetString(buffer2);
        }

        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream stream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(cipherData, 0, cipherData.Length);
            stream2.Close();
            return stream.ToArray();
        }

        private static string Encrypt(string clearText, string Password)
        {
            byte[] clearData = Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            return Convert.ToBase64String(Encrypt(clearData, bytes.GetBytes(0x20), bytes.GetBytes(0x10)));
        }

        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream stream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(clearData, 0, clearData.Length);
            stream2.Close();
            return stream.ToArray();
        }
    }
}
