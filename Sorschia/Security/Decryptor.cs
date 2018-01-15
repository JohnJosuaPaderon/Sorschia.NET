using Sorschia.Utilities;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sorschia.Security
{
    internal sealed class Decryptor : IDisposable
    {
        public Decryptor(string text, string password, bool compressed)
        {
            if (text == null)
            {
                throw SorschiaException.ParameterRequired(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw SorschiaException.ParameterRequired(nameof(password));
            }

            B_Password = Encoding.UTF8.GetBytes(password);
            B_PasswordHash = SHA256.Create().ComputeHash(B_Password);
            B_Text = Convert.FromBase64String(text);
            Compressed = compressed;
        }

        private byte[] B_Password { get; set; }
        private byte[] B_PasswordHash { get; set; }
        private byte[] B_Text { get; set; }
        private byte[] B_Decrypted { get; set; }
        private bool Compressed { get; }

        public string Execute()
        {
            AesDecrypt();

            var b_Result = new byte[B_Decrypted.Length - RandomBytes.SaltLength];

            for (int i = 0; i < b_Result.Length; i++)
            {
                b_Result[i] = B_Decrypted[i + RandomBytes.SaltLength];
            }

            if (Compressed)
            {
                b_Result = Compressor.Decompress(b_Result);
            }

            return Encoding.UTF8.GetString(b_Result);
        }

        private void AesDecrypt()
        {
            var b_Salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (var memoryStream = new MemoryStream())
            {
                using (var rijndaelManaged = Crypto.GetAes())
                {
                    var key = new Rfc2898DeriveBytes(B_PasswordHash, b_Salt, 1000);
                    rijndaelManaged.Key = key.GetBytes(rijndaelManaged.KeySize / 8);
                    rijndaelManaged.IV = key.GetBytes(rijndaelManaged.BlockSize / 8);

                    using (var cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(B_Text, 0, B_Text.Length);
                    }

                    B_Decrypted = memoryStream.ToArray();
                }
            }
        }

        public void Dispose()
        {
            B_Password = null;
            B_Decrypted = null;
            B_PasswordHash = null;
            B_Text = null;
        }
    }
}
