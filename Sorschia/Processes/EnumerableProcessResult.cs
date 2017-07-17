using System;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public struct EnumerableProcessResult<T> : IEnumerableProcessResult<T>
    {
        public EnumerableProcessResult(Exception exception) : this(null, ProcessResultStatus.Failed, "An exception has been thrown.", exception)
        {

        }

        public EnumerableProcessResult(ProcessResultStatus status, string message) : this(null, status, message)
        {

        }

        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status) : this(dataList, status, null)
        {

        }

        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message) : this(dataList, status, message, null)
        {

        }

        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message, Exception exception)
        {
            DataList = dataList;
            Status = status;
            Message = message;
            Exception = exception;
        }

        public IEnumerable<T> DataList { get; }

        public ProcessResultStatus Status { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
