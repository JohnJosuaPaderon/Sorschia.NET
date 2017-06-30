using System.Collections.Generic;

namespace Sorschia
{
    public interface IEnumerableDataProcessResult<T> : IProcessResult
    {
        IEnumerable<T> DataList { get; }
    }
}
