using Sorschia.Security;

namespace Sorschia.Configuration
{
    public sealed class ConnectionStringCryptoService : CryptoServiceBase, IConnectionStringCryptoService
    {
        public ConnectionStringCryptoService(ICryptoKeyProvider keyProvider, IEncryptor encryptor, IDecryptor decryptor) : base(keyProvider, encryptor, decryptor, "ConnectionString")
        {
        }
    }
}
