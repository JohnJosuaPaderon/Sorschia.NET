namespace Sorschia
{
    public struct ProcessResult : IProcessResult
    {
        public ProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public ProcessResult(ProcessResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        public ProcessResultStatus Status { get; }
        public string Message { get; }
    }
}
