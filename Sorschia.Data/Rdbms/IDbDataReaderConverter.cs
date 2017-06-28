using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data.Rdbms
{
    public interface IDbDataReaderConverter<TDataReader, TResult>
        where TDataReader : DbDataReader
    {
        TResult Convert(TDataReader reader);
        Task<TResult> ConvertAsync(TDataReader reader);
        Task<TResult> ConvertAsync(TDataReader reader, CancellationToken cancellationToken);
    }
}
