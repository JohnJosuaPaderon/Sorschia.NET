using System;

namespace Sorschia.Processing
{
    [Flags]
    public enum ProcessResultStatus
    {
        None = 0,
        Success = 1,
        Failed = 2,
        Undefined = 4
    }
}
