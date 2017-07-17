using System;

namespace Sorschia.Processes
{
    public struct ProcessResult : IProcessResult
    {
        public ProcessResult(Exception exception) : this(null, ProcessResultStatus.Failed, "An exception has been thrown.", exception)
        {

        }

        public ProcessResult(ProcessResultStatus status, string message) : this(null, status, message)
        {

        }

        public ProcessResult(object data, ProcessResultStatus status) : this(data, status, null)
        {

        }

        public ProcessResult(object data, ProcessResultStatus status, string message) : this(data, status, message, null)
        {

        }

        public ProcessResult(object data, ProcessResultStatus status, string message, Exception exception)
        {
            Data = data;
            Status = status;
            Message = message;
            Exception = exception;
        }

        public object Data { get; }
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }

    public struct ProcessResult<T> : IProcessResult<T>
    {
        public ProcessResult(Exception exception) : this(default(T), ProcessResultStatus.Failed, "An exception has been thrown.", exception)
        {

        }

        public ProcessResult(ProcessResultStatus status, string message) : this(default(T), status, message)
        {

        }

        public ProcessResult(T data, ProcessResultStatus status) : this(data, status, null)
        {

        }

        public ProcessResult(T data, ProcessResultStatus status, string message) : this(data, status, message, null)
        {

        }

        public ProcessResult(T data, ProcessResultStatus status, string message, Exception exception)
        {
            Data = data;
            Status = status;
            Message = message;
            Exception = exception;
        }

        public T Data { get; }
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
