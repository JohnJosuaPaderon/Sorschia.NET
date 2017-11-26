using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Sorschia.Application
{
    public interface ISorschiaBootstrapper
    {
        IServiceCollection Services { get; }
        Dictionary<AppDirectoryType, string> AppDirectories { get; }
        string ConfigurationFilePath { get; }
    }
}
