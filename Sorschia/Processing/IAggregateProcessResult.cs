using System.Collections.Generic;

namespace Sorschia.Processing
{
    public interface IAggregateProcessResult : IProcessResult
    {
        void Add(IProcessResult result);
        IEnumerable<IProcessResult> Results { get; }
        IProcessResult Flatten();
    }
}
