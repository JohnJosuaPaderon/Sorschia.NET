using System;
using System.Security;

namespace Sorschia.Security
{
    public abstract class CryptoKeyLoaderBase : IDisposable
    {
        public CryptoKeyLoaderBase(SecureString secureCryptoKey)
        {
            _SecureCryptoKey = secureCryptoKey;
        }

        private readonly SecureString _SecureCryptoKey;

        public void Dispose()
        {
            _SecureCryptoKey.Dispose();
        }
    }
}
