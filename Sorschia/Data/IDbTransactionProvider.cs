using Sorschia.Processing;
using System.Data.Common;

namespace Sorschia.Data
{
    public interface IDbTransactionProvider<TTransaction>
        where TTransaction : DbTransaction
    {
        TTransaction this[IProcessContext processContext] { get; }
        void Dispose(IProcessContext processContext);
    }
}
