using Sorschia.Processing;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbHelper<TCommand, TQueryParameter>
        where TCommand : DbCommand
        where TQueryParameter : IQueryParameter
    {
        IProcessResult ExecuteNonQuery(IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(IQuery<TCommand, TQueryParameter> query, CancellationToken cancellationToken);
    }
}
