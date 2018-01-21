using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Processing
{
    public abstract class AggregateProcessResultBase
    {
        protected IProcessResult Flatten<T>(IEnumerable<T> results)
            where T : IProcessResult
        {
            if (results.Any())
            {
                return UnsafeFlatten(results);
            }
            else
            {
                return new ProcessResult(ProcessResultStatus.Undefined, "No results supplied.");
            }
        }

        private IProcessResult UnsafeFlatten<T>(IEnumerable<T> results)
            where T : IProcessResult
        {
            var iterationResult = Iterate(results);
            var message = ExtractMessage(iterationResult.messages);
            var status = ExtractStatus(iterationResult.successCount, iterationResult.failedCount);
            var exception = ExtractException(iterationResult.exceptions);

            return new ProcessResult(status, message, exception);
        }

        private (IEnumerable<string> messages, IEnumerable<Exception> exceptions, int successCount, int failedCount) Iterate<T>(IEnumerable<T> results)
            where T : IProcessResult
        {
            var messages = new List<string>();
            var exceptions = new List<Exception>();
            var successCount = 0;
            var failedCount = 0;

            foreach (var result in results)
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
                        successCount++;
                        break;
                    case ProcessResultStatus.Failed:
                        failedCount++;
                        break;
                }
            }

            return (messages, exceptions, successCount, failedCount);
        }

        private string ExtractMessage(IEnumerable<string> messages)
        {
            string message;
            switch (messages.Count())
            {
                case 0:
                    message = "No result messages.";
                    break;
                case 1:
                    message = messages.First();
                    break;
                default:
                    message = "Multiple result messages supplied.";
                    break;
            }

            return message;
        }

        private ProcessResultStatus ExtractStatus(int successCount, int failedCount)
        {
            if (successCount > 0 && failedCount > 0)
            {
                return ProcessResultStatus.Undefined;
            }
            else if (successCount > 0)
            {
                return ProcessResultStatus.Success;
            }
            else if (failedCount > 0)
            {
                 return ProcessResultStatus.Failed;
            }
            else
            {
                return ProcessResultStatus.None;
            }
        }

        private Exception ExtractException(IEnumerable<Exception> exceptions)
        {
            if (exceptions.Any())
            {
                return new AggregateException(exceptions);
            }
            else
            {
                return null;
            }
        }
    }
}
