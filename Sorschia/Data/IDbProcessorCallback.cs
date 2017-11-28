using Sorschia.Processing;
using System.Data.Common;

namespace Sorschia.Data
{
    public delegate IProcessResult<T> IDbProcessorCallback<T, TCommand>(TCommand command, int affectedRows)
        where TCommand : DbCommand;
}
