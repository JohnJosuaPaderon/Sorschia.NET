using System.Collections.Generic;

namespace Sorschia.Processing
{
    public sealed partial class AggregateProcessResult : AggregateProcessResultBase, IAggregateProcessResult
    {
        public AggregateProcessResult()
        {
            _Results = new List<IProcessResult>();
        }
    }

    public sealed partial class AggregateProcessResult<T> : AggregateProcessResultBase, IAggregateProcessResult<T>
    {
        public AggregateProcessResult()
        {
            _Results = new List<IProcessResult<T>>();
        }
    }
}
