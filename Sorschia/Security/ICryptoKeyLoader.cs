using System;

namespace Sorschia.Security
{
    public interface ICryptoKeyLoader : IDisposable
    {
        void Load(ICryptoKeyProvider recipient);
    }
}
