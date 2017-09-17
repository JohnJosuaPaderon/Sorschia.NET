using Sorschia.Processing;

namespace Sorschia.Data
{
    public delegate IProcessResult GetProcessResultDelegate<TCommand>(TCommand command, int affectedRows);
    public delegate IProcessResult<T> GetProcessResultDelegate<T, TCommand>(TCommand command, int affectedRows);
}
