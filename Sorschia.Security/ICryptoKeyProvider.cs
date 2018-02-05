using System.Security;

namespace Sorschia.Security
{
    public interface ICryptoKeyProvider
    {
        SecureString this[string name] { get; set; }
        void Add(string name, SecureString secureCryptoKey);
        bool Remove(string name);
        void Clear();
        void Initialize();
    }
}
