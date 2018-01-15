using System;

namespace Sorschia.Logging
{
    public interface ISystemLogHeader
    {
        string Title { get; set; }
        DateTime LogDate { get; set; }
    }
}
