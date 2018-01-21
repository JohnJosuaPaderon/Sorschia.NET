namespace Sorschia.Processing
{
    partial class AggregateProcessResult
    {
        public void Add(IProcessResult result)
        {
            Status = result.Status;
            Message = result.Message;
            Exception = result.Exception;

            _Results.Add(result);
        }

        public IProcessResult Flatten()
        {
            return Flatten(_Results);
        }
    }

    partial class AggregateProcessResult<T>
    {
        public void Add(IProcessResult<T> result)
        {
            Status = result.Status;
            Message = result.Message;
            Exception = result.Exception;

            _Results.Add(result);
        }

        public IProcessResult Flatten()
        {
            return Flatten(_Results);
        }
    }
}
