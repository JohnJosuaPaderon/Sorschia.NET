using System;

namespace Sorschia.Processing
{
    partial class ProcessResult
    {
        public static ProcessResult Failed(string message)
        {
            return new ProcessResult(ProcessResultStatus.Failed, message);
        }

        public static ProcessResult Failed(Exception exception)
        {
            return new ProcessResult(ProcessResultStatus.Failed, ProcessResultMessage.ExceptionThrown, exception);
        }

        public static ProcessResult Failed(string message, Exception exception)
        {
            return new ProcessResult(ProcessResultStatus.Failed, message, exception);
        }

        public static ProcessResult Success()
        {
            return new ProcessResult(ProcessResultStatus.Success, ProcessResultMessage.Success);
        }

        public static ProcessResult Success(string message)
        {
            return new ProcessResult(ProcessResultStatus.Success, message);
        }
    }

    partial class ProcessResult<T>
    {
        public static ProcessResult<T> Failed(string message)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, message);
        }

        public static ProcessResult<T> Failed(Exception exception)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, ProcessResultMessage.ExceptionThrown, exception);
        }

        public static ProcessResult<T> Failed(string message, Exception exception)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, message, exception);
        }

        public static ProcessResult<T> Success(T data)
        {
            return new ProcessResult<T>(data, ProcessResultStatus.Success, ProcessResultMessage.Success);
        }

        public static ProcessResult<T> Success(T data, string message)
        {
            return new ProcessResult<T>(data, ProcessResultStatus.Success, message);
        }

        public static ProcessResult<T> NoResult()
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Undefined, ProcessResultMessage.NoResult);
        }
    }
}
