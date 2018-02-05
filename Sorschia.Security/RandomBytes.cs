using System.Security.Cryptography;

namespace Sorschia.Security
{
    public static class RandomBytes
    {
        static RandomBytes()
        {
            SaltLength = 8;
        }

        public static byte[] Get()
        {
            byte[] bytes = new byte[SaltLength];
            RandomNumberGenerator.Create().GetBytes(bytes);
            return bytes;
        }

        public static int SaltLength { get; }
    }
}
