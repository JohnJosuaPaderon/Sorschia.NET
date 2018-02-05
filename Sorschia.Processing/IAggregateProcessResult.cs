using System.Collections.Generic;

namespace Sorschia.Processing
{
    public interface IAggregateProcessResult : IProcessResult
    {
        void Add(IProcessResult result);
        IEnumerable<IProcessResult> Results { get; }
        IProcessResult Flatten();
    }

    public interface IAggregateProcessResult<T> : IProcessResult
    {
        void Add(IProcessResult<T> result);
        IEnumerable<IProcessResult<T>> Results { get; }
        IProcessResult Flatten();
    }
}
