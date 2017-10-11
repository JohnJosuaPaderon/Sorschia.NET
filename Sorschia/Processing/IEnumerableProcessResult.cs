using System.Collections.Generic;

namespace Sorschia.Processing
{
    public interface IEnumerableProcessResult<T> : IProcessResult
    {
        IEnumerable<T> DataCollection { get; }
    }
}
