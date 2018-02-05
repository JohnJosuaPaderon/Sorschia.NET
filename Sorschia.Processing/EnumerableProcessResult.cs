using System;
using System.Collections.Generic;

namespace Sorschia.Processing
{
    public partial class EnumerableProcessResult<T> : IEnumerableProcessResult<T>
    {
        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message, Exception exception = null)
        {
            DataCollection = dataList;
            Status = status;
            Message = message;
            Exception = exception;
        }
    }
}
