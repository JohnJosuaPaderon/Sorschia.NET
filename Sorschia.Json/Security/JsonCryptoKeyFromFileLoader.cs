using System.Security;

namespace Sorschia.Security
{
    public sealed class JsonCryptoKeyFromFileLoader : CryptoKeyLoaderBase, ICryptoKeyLoader
    {
        public JsonCryptoKeyFromFileLoader(string filePath, SecureString secureCryptoKey) : base(secureCryptoKey)
        {

        }

        public void Load(ICryptoKeyProvider recipient)
        {

        }
    }
}
