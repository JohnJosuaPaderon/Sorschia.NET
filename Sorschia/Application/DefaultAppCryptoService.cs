using Sorschia.Security;

namespace Sorschia.Application
{
    public sealed class DefaultAppCryptoService : CryptoServiceBase, IAppCryptoService
    {
        public DefaultAppCryptoService(
            ICryptoKeyProvider keyProvider,
            IEncryptor encryptor,
            IDecryptor decryptor) : base(keyProvider, encryptor, decryptor, typeof(IAppCryptoService).FullName)
        {
        }
    }
}
