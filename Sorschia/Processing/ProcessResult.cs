using System;

namespace Sorschia.Processing
{
    public class ProcessResult : IProcessResult
    {
        public static ProcessResult Failed(string message)
        {
            return new ProcessResult(ProcessResultStatus.Failed, message);
        }

        public static ProcessResult Failed(Exception exception)
        {
            return new ProcessResult(ProcessResultStatus.Failed, "An exception has been thrown.", exception);
        }

        public static ProcessResult Failed(string message, Exception exception)
        {
            return new ProcessResult(ProcessResultStatus.Failed, message, exception);
        }

        public static ProcessResult Success()
        {
            return new ProcessResult(ProcessResultStatus.Success, "Process successfully completed.");
        }

        public static ProcessResult Success(string message)
        {
            return new ProcessResult(ProcessResultStatus.Success, message);
        }

        public ProcessResult(ProcessResultStatus status, string message, Exception exception = null)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }

        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }

    public class ProcessResult<T> : IProcessResult<T>
    {
        public static ProcessResult<T> Failed(string message)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, message);
        }

        public static ProcessResult<T> Failed(Exception exception)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, "An exception has been thrown.", exception);
        }

        public static ProcessResult<T> Failed(string message, Exception exception)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, message, exception);
        }

        public static ProcessResult<T> Success(T data)
        {
            return new ProcessResult<T>(data, ProcessResultStatus.Success, "Process successfully completed.");
        }

        public static ProcessResult<T> Success(T data, string message)
        {
            return new ProcessResult<T>(data, ProcessResultStatus.Success, message);
        }

        public ProcessResult(T data, ProcessResultStatus status, string message, Exception exception = null)
        {
            Status = status;
            Message = message;
            Exception = exception;
            Data = data;
        }

        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
    }
}
