using Sorschia.Processes;
using System.Data.Common;

namespace Sorschia.Data.Rdbms
{
    public delegate IProcessResult GetProcessResultDelegate<TCommand>(TCommand command, int affectedRows)
        where TCommand : DbCommand;

    public delegate IProcessResult<T> GetProcessResultDelegate<T, TCommand>(T data, TCommand command, int affectedRows)
        where TCommand : DbCommand;
}
