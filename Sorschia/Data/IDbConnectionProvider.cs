using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbConnectionProvider<TConnection>
        where TConnection : DbConnection
    {
        TConnection Establish(string connectionStringKey);
        TConnection Establish(string connectionStringKey, Guid guid);
        Task<TConnection> EstablishAsync(string connectionStringKey);
        Task<TConnection> EstablishAsync(string connectionStringKey, Guid guid);
        Task<TConnection> EstablishAsync(string connectionStringKey, CancellationToken cancellationToken);
        Task<TConnection> EstablishAsync(string connectionStringKey, CancellationToken cancellationToken, Guid guid);
        TConnection GetConnection(Guid guid);
    }
}
