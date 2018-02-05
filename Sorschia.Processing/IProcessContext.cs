using System;

namespace Sorschia.Processing
{
    public interface IProcessContext : IDisposable
    {
        Guid Guid { get; }
        bool IsFaulted { get; set; }
    }
}
