using System.Collections.Generic;

namespace Sorschia
{
    public interface IDataProcessResult<T> : IProcessResult
    {
        T Data { get; }
    }

    public interface IEnumerableDataProcessResult<T> : IProcessResult
    {
        IEnumerable<T> DataList { get; }
    }
}
