using Sorschia.Processing;
using System.Collections.Generic;
using System.Data.Common;

namespace Sorschia.Data
{
    public abstract partial class DbConnectionProviderBase<TConnection> : IDbConnectionProvider<TConnection>
        where TConnection : DbConnection
    {
        public DbConnectionProviderBase()
        {
            _Source = new Dictionary<IProcessContext, TConnection>();
        }

        protected readonly Dictionary<IProcessContext, TConnection> _Source;

        protected abstract TConnection Instantiate(IProcessContext processContext);

        public void CloseDispose(IProcessContext processContext)
        {
            var connection = _Source[processContext];

            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                _Source.Remove(processContext);
            }
        }
    }
}
