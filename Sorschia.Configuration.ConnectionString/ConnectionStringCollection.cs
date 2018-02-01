using System.Collections.Generic;

namespace Sorschia.Configuration
{
    public sealed partial class ConnectionStringCollection : IConnectionStringCollection
    {
        public ConnectionStringCollection()
        {
            _Source = new Dictionary<string, IConnectionString>();
        }
    }
}
