using System;

namespace Sorschia.Application
{
    public interface ISorschiaApp
    {
        IServiceProvider ServiceProvider { get; }
        IAppDirectoryCollection Directories { get; }
        IAppFileCollection Files { get; }
        IAppSettingCollection Settings { get; }
    }
}
