using System;
using System.Collections.Generic;

namespace Sorschia.Processing
{
    public class EnumerableProcessResult<T> : IEnumerableProcessResult<T>
    {
        public static EnumerableProcessResult<T> Failed(string message)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, message);
        }

        public static EnumerableProcessResult<T> Failed(Exception exception)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, ProcessResultMessage.ExceptionThrown, exception);
        }

        public static EnumerableProcessResult<T> Failed(string message, Exception exception)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, message, exception);
        }

        public static EnumerableProcessResult<T> Success(IEnumerable<T> dataList)
        {
            return new EnumerableProcessResult<T>(dataList, ProcessResultStatus.Success, ProcessResultMessage.Success);
        }

        public static EnumerableProcessResult<T> Success(IEnumerable<T> dataList, string message)
        {
            return new EnumerableProcessResult<T>(dataList, ProcessResultStatus.Success, message);
        }

        public static EnumerableProcessResult<T> NoResult()
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Undefined, ProcessResultMessage.NoResult);
        }

        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message, Exception exception = null)
        {
            DataCollection = dataList;
            Status = status;
            Message = message;
            Exception = exception;
        }

        public IEnumerable<T> DataCollection { get; }
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
