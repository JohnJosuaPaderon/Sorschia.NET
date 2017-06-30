using System.Collections.Generic;

namespace Sorschia
{
    public interface IDataProcessResult<T> : IProcessResult
    {
        T Data { get; }
    }
}
