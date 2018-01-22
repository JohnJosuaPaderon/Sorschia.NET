using System.Collections.Generic;
using System.Security;

namespace Sorschia.Configuration
{
    public abstract partial class ConnectionStringSourceBase : IConnectionStringSource
    {
        public ConnectionStringSourceBase(IConnectionStringSourceLoader loader)
        {
            IsLoaded = false;
            _SecureSource = new Dictionary<string, SecureString>();
            _Loader = loader;
        }
    }
}
