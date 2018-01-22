using System.Collections.Generic;
using System.Security;

namespace Sorschia.Configuration
{
    partial class ConnectionStringSourceBase
    {
        private readonly Dictionary<string, SecureString> _SecureSource;
        private readonly IConnectionStringSourceLoader _Loader;

        private bool IsLoaded;
        public bool IsEncrypted { get; set; }
    }
}
