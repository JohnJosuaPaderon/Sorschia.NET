using System;

namespace Sorschia.Application
{
    public interface IAppSession
    {
        Guid Id { get; }
        DateTime? Begin { get; }
        DateTime? End { get; }
        void Start();
        void Stop();
    }
}
