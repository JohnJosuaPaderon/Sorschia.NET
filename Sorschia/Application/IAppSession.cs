using System;

namespace Sorschia.Application
{
    public interface IAppSession
    {
        DateTime? Begin { get; }
        DateTime? End { get; }
        void Start();
        void Stop();
    }
}
