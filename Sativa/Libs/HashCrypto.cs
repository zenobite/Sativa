using System;
using System.Text;
using System.Security.Cryptography;

namespace Sativa.Libs
{
    /// <summary>
    /// Hash Crypto Data Library Class
    /// </summary>
    public class HashCrypto
    {
        private static string key = "SATIVA";
        private static string IV = "SVectorIV";

        public static string Encrypt(string text)
        {
            try
            {
                byte[] keyByte = Encoding.ASCII.GetBytes(key);
                byte[] IVByte = Encoding.ASCII.GetBytes(IV);
                byte[] textByte = Encoding.ASCII.GetBytes(text);

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                aes.Key = sha256.ComputeHash(keyByte);
                aes.IV = IVByte;

                return Convert.ToBase64String(aes.CreateEncryptor().TransformFinalBlock(textByte, 0, textByte.Length));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string text)
        {
            try
            {
                byte[] keyByte = Encoding.ASCII.GetBytes(key);
                byte[] IVByte = Encoding.ASCII.GetBytes(IV);
                byte[] textByte = Convert.FromBase64String(text);

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                aes.Key = sha256.ComputeHash(keyByte);
                aes.IV = IVByte;

                return Encoding.ASCII.GetString(aes.CreateDecryptor().TransformFinalBlock(textByte, 0, textByte.Length));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static byte[] Encrypt(byte[] obj)
        {
            try
            {
                byte[] keyByte = Encoding.ASCII.GetBytes(key);
                byte[] IVByte = Encoding.ASCII.GetBytes(IV);

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                aes.Key = sha256.ComputeHash(keyByte);
                aes.IV = IVByte;

                return aes.CreateEncryptor().TransformFinalBlock(obj, 0, obj.Length);
            }
            catch
            {
                return null;
            }
        }

        public static byte[] Decrypt(byte[] obj)
        {
            try
            {
                byte[] keyByte = Encoding.ASCII.GetBytes(key);
                byte[] IVByte = Encoding.ASCII.GetBytes(IV);

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                aes.Key = sha256.ComputeHash(keyByte);
                aes.IV = IVByte;

                return aes.CreateDecryptor().TransformFinalBlock(obj, 0, obj.Length);
            }
            catch
            {
                return null;
            }
        }
    }
}