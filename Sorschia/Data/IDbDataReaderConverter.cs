using Sorschia.Processing;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbDataReaderConverter<T>
    {
        IProcessResult<T> FromReader(DbDataReader reader);
        Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader);
        Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> EnumerableFromReader(DbDataReader reader);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken);
    }
}
