namespace Sorschia.Processing
{
    partial class AggregateProcessResult
    {
        public static AggregateProcessResult Failed(string message)
        {
            return new AggregateProcessResult
            {
                Exception = null,
                Message = message,
                Status = ProcessResultStatus.Failed
            };
        }
    }

    partial class AggregateProcessResult<T>
    {
        public static AggregateProcessResult<T> Failed(string message)
        {
            return new AggregateProcessResult<T>
            {
                Exception = null,
                Message = message,
                Status = ProcessResultStatus.Failed
            };
        }
    }
}
