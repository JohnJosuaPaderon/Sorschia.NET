using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data;
using Sorschia.Repository;
using Sorschia.Utilities;
using System;

namespace Sorschia.Application
{
    public sealed class SorschiaApp : ISorschiaApp
    {
        static SorschiaApp()
        {
            _Builder = new SorschiaAppBuilder();
        }

        public static ISorschiaApp Current { get; private set; }

        private static void ValidateCurrent()
        {
            if (Current == null)
            {
                throw SorschiaException.AppFailure("Sorschia.Application.SorschiaApp.Current is not built.");
            }
        }

        public static T GetService<T>()
        {
            ValidateCurrent();
            return Current.ServiceProvider.GetService<T>();
        }

        public static T GetRepository<T>(bool forceInitialize = false)
            where T : IRepository
        {
            var repository = GetService<T>();

            if (forceInitialize)
            {
                repository.Initialize();
            }
            else
            {
                repository.TryInitialize();
            }

            return repository;
        }

        public static T GetDataService<T>()
            where T : IDataService
        {
            var dataService = GetService<T>();
            dataService.Initialize();
            return dataService;
        }

        public static string GetDirectory(string key)
        {
            ValidateCurrent();
            return Current.GetAppDirectory(key);
        }

        public static string GetFile(string key)
        {
            ValidateCurrent();
            return Current.GetAppFile(key);
        }

        public static string GetSetting(string key)
        {
            ValidateCurrent();
            return Current.GetAppSetting(key);
        }

        private static readonly SorschiaAppBuilder _Builder;

        public static void Build(IAppConfigurationLoader configurationLoader, ISorschiaBootstrapper bootstrapper)
        {
            _Builder.Bootstrapper = bootstrapper;
            _Builder.ConfigurationLoader = configurationLoader;

            Current = _Builder.Build();
        }

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
