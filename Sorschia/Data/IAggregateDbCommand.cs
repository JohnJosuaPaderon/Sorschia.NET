using System.Collections.Generic;
using System.Data.Common;

namespace Sorschia.Data
{
    public interface IAggregateDbCommand<TCommand> : IEnumerable<TCommand>
        where TCommand : DbCommand
    {
        Dictionary<string, object> BindedValues { get; }
    }
}
