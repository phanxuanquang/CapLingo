using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public static class CriptographyHelper
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("phanxuanquang@2025/CapLingo");

        public static string Encrypt(string text)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.GenerateIV();
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();
            msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(text);
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string text)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            byte[] iv = new byte[16];
            Array.Copy(Convert.FromBase64String(text), iv, 16);
            aesAlg.IV = iv;
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msDecrypt = new(Convert.FromBase64String(text));
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}
