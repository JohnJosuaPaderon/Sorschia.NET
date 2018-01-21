using System;

namespace Sorschia.Processing
{
    partial class ProcessResult
    {
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }

    partial class ProcessResult<T>
    {
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
    }
}
