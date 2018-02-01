using System.Collections.Generic;
using System.Security;

namespace Sorschia.Configuration
{
    partial class ConnectionStringCollection
    {
        private readonly Dictionary<string, IConnectionString> _Source;
    }
}
