using System.Security;

namespace Sorschia.Security
{
    public interface IEncryptor
    {
        string Encrypt(string text, SecureString secureCryptoKey, bool isCompressed);
    }
}
