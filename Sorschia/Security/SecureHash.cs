using Sorschia.Utilities;
using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Sorschia.Security
{
    public static class SecureHash
    {
        private static string ComputeHash(string value, HashAlgorithm algorithm)
        {
            using (algorithm)
            {
                var computedHash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
                return BitConverter.ToString(computedHash).Replace("-", string.Empty);
            }
        }

        public static string ComputeSha256(string value)
        {
            return ComputeHash(value, SHA256.Create());
        }

        public static string ComputeSha256(SecureString secureValue)
        {
            return ComputeSha256(SecureStringConverter.Convert(secureValue));
        }

        public static string ComputeSha512(string value)
        {
            return ComputeHash(value, SHA512.Create());
        }

        public static string ComputeSha512(SecureString secureValue)
        {
            return ComputeSha512(SecureStringConverter.Convert(secureValue));
        }
    }
}
