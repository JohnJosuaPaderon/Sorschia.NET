using System;

namespace Sorschia
{
    public interface ISorschiaApp
    {
        IServiceProvider ServiceProvider { get; }
        string AppDirectory { get; }
    }
}
