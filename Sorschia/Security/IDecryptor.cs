using System.Security;

namespace Sorschia.Security
{
    public interface IDecryptor
    {
        string Decrypt(string text, SecureString secureCryptoKey, bool IsCompressed);
    }
}
