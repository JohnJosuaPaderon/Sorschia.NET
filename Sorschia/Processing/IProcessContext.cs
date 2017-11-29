using System;

namespace Sorschia.Processing
{
    public interface IProcessContext
    {
        Guid Guid { get; }
        bool IsFaulted { get; set; }
    }
}
