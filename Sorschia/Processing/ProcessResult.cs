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
            return new ProcessResult(ProcessResultStatus.Success, "Process successfully performed.");
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
}
