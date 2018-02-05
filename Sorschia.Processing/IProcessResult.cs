using System;

namespace Sorschia.Processing
{
    public interface IProcessResult
    {
        ProcessResultStatus Status { get; }
        string Message { get; }
        Exception Exception { get; }
    }

    public interface IProcessResult<T> : IProcessResult
    {
        T Data { get; }
    }
}
