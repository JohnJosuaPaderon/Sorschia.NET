using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbConnectionProvider<TConnection>
        where TConnection : DbConnection
    {
        TConnection Establish(string connectionStringKey);
        Task<TConnection> EstablishAsync(string connectionStringKey);
        Task<TConnection> EstablishAsync(string connectionStringKey, CancellationToken cancellationToken);
    }
}
