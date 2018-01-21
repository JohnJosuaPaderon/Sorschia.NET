using System;
using System.Collections.Generic;

namespace Sorschia.Processing
{
    partial class EnumerableProcessResult<T>
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
    }
}
