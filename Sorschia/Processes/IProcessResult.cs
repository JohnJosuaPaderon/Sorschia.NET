using System;

namespace Sorschia.Processes
{
    public interface IProcessResult
    {
        object Data { get; }
        ProcessResultStatus Status { get; }
        string Message { get; }
        Exception Exception { get; }
    }

    public interface IProcessResult<T>
    {
        T Data { get; }
        ProcessResultStatus Status { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}
