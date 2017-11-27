using System;
using Microsoft.Extensions.DependencyInjection;

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

        public static string GetDirectory(AppDirectoryType type)
        {
            ValidateCurrent();
            return Current.Directories[type].Path;
        }

        public static string GetFile(AppFileType type)
        {
            ValidateCurrent();
            return Current.Files[type].Path;
        }

        public static string GetSetting(string key)
        {
            ValidateCurrent();
            return Current.Settings[key].Value;
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

        public IServiceProvider ServiceProvider { get; }
        public IAppDirectoryCollection Directories { get; }
        public IAppFileCollection Files { get; }
        public IAppSettingCollection Settings { get; }
    }
}
