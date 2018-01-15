using System;

namespace Sorschia.Logging
{
    public interface ISystemLog
    {
        Guid Guid { get; }
        ISystemLogHeader Header { get; }
        ISystemLogBody Body { get; }
    }
}
