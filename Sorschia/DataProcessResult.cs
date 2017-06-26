namespace Sorschia
{
    public struct DataProcessResult<T> : IDataProcessResult<T>
    {
        public DataProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public DataProcessResult(T data, ProcessResultStatus status) : this(data, status, null)
        {

        }

        public DataProcessResult(ProcessResultStatus status, string message)
        {
            Data = default(T);
            Status = status;
            Message = message;
        }

        public DataProcessResult(T data, ProcessResultStatus status, string message)
        {
            Data = data;
            Status = status;
            Message = message;
        }

        public T Data { get; }
        public ProcessResultStatus Status { get; }
        public string Message { get; }
    }
}
