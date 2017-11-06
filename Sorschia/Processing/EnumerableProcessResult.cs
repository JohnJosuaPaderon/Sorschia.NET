using System;
using System.Collections.Generic;

namespace Sorschia.Processing
{
    public class EnumerableProcessResult<T> : IEnumerableProcessResult<T>
    {
        private const string MESSAGE_EXCEPTION_THROWN = "An exception has been thrown.";
        private const string MESSAGE_SUCCESS = "Process successfully completed.";
        private const string MESSAGE_NO_RESULT = "Process successfully completed but has no result.";

        public static EnumerableProcessResult<T> Failed(string message)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, message);
        }

        public static EnumerableProcessResult<T> Failed(Exception exception)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, MESSAGE_EXCEPTION_THROWN, exception);
        }

        public static EnumerableProcessResult<T> Failed(string message, Exception exception)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, message, exception);
        }

        public static EnumerableProcessResult<T> Success(IEnumerable<T> dataList)
        {
            return new EnumerableProcessResult<T>(dataList, ProcessResultStatus.Success, MESSAGE_SUCCESS);
        }

        public static EnumerableProcessResult<T> Success(IEnumerable<T> dataList, string message)
        {
            return new EnumerableProcessResult<T>(dataList, ProcessResultStatus.Success, message);
        }

        public static EnumerableProcessResult<T> NoResult()
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Undefined, MESSAGE_NO_RESULT);
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
