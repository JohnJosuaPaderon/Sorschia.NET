using System.Data.Common;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DataAccess.Rdbms
{
    public interface IDbConnectionEstablisher<TConnection>
        where TConnection : DbConnection
    {
        SecureString SecureConnectionString { get; set; }
        TConnection Establish();
        Task<TConnection> EstablishAsync();
        Task<TConnection> EstablishAsync(CancellationToken cancellationToken);
    }
}
