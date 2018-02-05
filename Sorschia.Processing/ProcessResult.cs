using System;

namespace Sorschia.Processing
{
    public partial class ProcessResult : IProcessResult
    {
        public ProcessResult(ProcessResultStatus status, string message, Exception exception = null)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }
    }

    public partial class ProcessResult<T> : IProcessResult<T>
    {
        public ProcessResult(T data, ProcessResultStatus status, string message, Exception exception = null)
        {
            Status = status;
            Message = message;
            Exception = exception;
            Data = data;
        }
    }
}
