using Sorschia.Processing;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbCommandCreator<TCommand>
        where TCommand : DbCommand
    {
        TCommand Create(IDbQuery query, IProcessContext processContext);
        Task<TCommand> CreateAsync(IDbQuery query, IProcessContext processContext);
        Task<TCommand> CreateAsync(IDbQuery query, IProcessContext processContext, CancellationToken cancellationToken);
    }
}
