using Microsoft.Extensions.DependencyInjection;
using Sorschia.Utilities;
using System;

namespace Sorschia.Application
{
    public sealed partial class SorschiaApp : ISorschiaApp
    {
        internal SorschiaApp(IServiceProvider serviceProvider, IAppDirectoryCollection directories, IAppFileCollection files, IAppSettingCollection settings)
        {
            ServiceProvider = serviceProvider;
            Directories = directories;
            Files = files;
            Settings = settings;
        }

        private IAppCryptoService _CryptoService;

        public IServiceProvider ServiceProvider { get; }
        public IAppDirectoryCollection Directories { get; }
        public IAppFileCollection Files { get; }
        public IAppSettingCollection Settings { get; }

        public IAppCryptoService CryptoService
        {
            get
            {
                if (_CryptoService == null)
                {
                    _CryptoService = ServiceProvider.GetService<IAppCryptoService>();
                }

                return _CryptoService;
            }
        }

        public string GetAppDirectory(string key)
        {
            return DirectoryResolver.Resolve(this, Directories[key].Path);
        }

        public string GetAppFile(string key)
        {
            return DirectoryResolver.Resolve(this, Files[key].Path);
        }

        public string GetAppSetting(string key)
        {
            return Settings[key].Value;
        }
    }
}
