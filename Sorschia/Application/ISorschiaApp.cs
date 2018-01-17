using System;

namespace Sorschia.Application
{
    public interface ISorschiaApp
    {
        IServiceProvider ServiceProvider { get; }
        IAppDirectoryCollection Directories { get; }
        IAppFileCollection Files { get; }
        IAppSettingCollection Settings { get; }
        IAppCryptoService CryptoService { get; }
        string GetAppDirectory(string key);
        string GetAppFile(string key);
        string GetAppSetting(string key);
        void Start();
        void Stop();
    }
}
