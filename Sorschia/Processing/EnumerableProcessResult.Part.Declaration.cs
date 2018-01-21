using System;
using System.Collections.Generic;

namespace Sorschia.Processing
{
    partial class EnumerableProcessResult<T>
    {
        public IEnumerable<T> DataCollection { get; }
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
