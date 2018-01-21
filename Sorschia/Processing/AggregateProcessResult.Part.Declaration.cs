using System;
using System.Collections.Generic;

namespace Sorschia.Processing
{
    partial class AggregateProcessResult
    {
        private readonly List<IProcessResult> _Results;

        public ProcessResultStatus Status { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }
        public IEnumerable<IProcessResult> Results => _Results;
    }

    partial class AggregateProcessResult<T>
    {
        private readonly List<IProcessResult<T>> _Results;

        public ProcessResultStatus Status { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }
        public IEnumerable<IProcessResult<T>> Results => _Results;
    }
}
