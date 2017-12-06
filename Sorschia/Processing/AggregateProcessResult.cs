using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Processing
{
    public sealed class AggregateProcessResult : IAggregateProcessResult
    {
        public AggregateProcessResult()
        {
            _Results = new List<IProcessResult>();
        }

        private readonly List<IProcessResult> _Results;

        public ProcessResultStatus Status { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }
        public IEnumerable<IProcessResult> Results => _Results;

        public void Add(IProcessResult result)
        {
            Status = result.Status;
            Message = result.Message;
            Exception = result.Exception;

            _Results.Add(result);
        }

        public IProcessResult Flatten()
        {
            var messages = new List<string>();
            var successCounter = 0;
            var failedCounter = 0;
            var exceptions = new List<Exception>();

            if (_Results.Any())
            {
                foreach (var result in _Results)
                {
                    if (!string.IsNullOrWhiteSpace(result.Message))
                    {
                        messages.Add(result.Message);
                    }

                    if (result.Exception != null)
                    {
                        exceptions.Add(result.Exception);
                    }

                    switch (result.Status)
                    {
                        case ProcessResultStatus.Success:
                            successCounter++;
                            break;
                        case ProcessResultStatus.Failed:
                            failedCounter++;
                            break;
                    }
                }

                string message = null;
                ProcessResultStatus status = ProcessResultStatus.None;
                Exception exception = null;

                switch (messages.Count)
                {
                    case 0:
                        message = "No result messages.";
                        break;
                    case 1:
                        message = messages[0];
                        break;
                    default:
                        message = "Multiple result messages supplied.";
                        break;
                }

                if (successCounter > 0 && failedCounter > 0)
                {
                    status = ProcessResultStatus.Undefined;
                }
                else if (successCounter > 0)
                {
                    status = ProcessResultStatus.Success;
                }
                else if (failedCounter > 0)
                {
                    status = ProcessResultStatus.Failed;
                }

                if (exceptions.Any())
                {
                    exception = new AggregateException(exceptions);
                }

                return new ProcessResult(status, message, exception);
            }
            else
            {
                return new ProcessResult(ProcessResultStatus.Undefined, "No results supplied.");
            }
        }
    }
}
