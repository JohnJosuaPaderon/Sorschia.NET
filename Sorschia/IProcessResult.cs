using System;

namespace Sorschia
{
    public interface IProcessResult
    {
        ProcessResultStatus Status { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}
