using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace Sorschia.Data
{
    public class AggregateDbCommand<TCommand> : IAggregateDbCommand<TCommand>
        where TCommand : DbCommand
    {
        internal AggregateDbCommand(IEnumerable<TCommand> commands)
        {
            _Commands = commands;
            BindedValues = new Dictionary<string, object>();
        }

        private readonly IEnumerable<TCommand> _Commands;
        public Dictionary<string, object> BindedValues { get; }

        public IEnumerator<TCommand> GetEnumerator()
        {
            return _Commands.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
