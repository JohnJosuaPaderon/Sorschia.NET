using System;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface IEnumerableProcessResult<T>
    {
        IEnumerable<T> DataList { get; }
        ProcessResultStatus Status { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}
