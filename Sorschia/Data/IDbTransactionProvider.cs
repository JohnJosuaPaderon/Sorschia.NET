using System.Data.Common;

namespace Sorschia.Data
{
    public interface IDbTransactionProvider<TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        TTransaction Initialize(TConnection connection);
    }
}
