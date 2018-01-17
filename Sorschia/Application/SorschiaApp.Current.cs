using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data;
using Sorschia.Repository;

namespace Sorschia.Application
{
    partial class SorschiaApp
    {
        static SorschiaApp()
        {
            _Builder = new SorschiaAppBuilder();
        }

        private static readonly SorschiaAppBuilder _Builder;
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

        public static T GetDataService<T>(bool forceInitialize = false)
            where T : IDataService
        {
            var dataService = GetService<T>();

            if (forceInitialize)
            {
                dataService.Initialize();
            }
            else
            {
                dataService.TryInitialize();
            }

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

        public static void Build(IAppConfigurationLoader configurationLoader, ISorschiaBootstrapper bootstrapper)
        {
            _Builder.Bootstrapper = bootstrapper;
            _Builder.ConfigurationLoader = configurationLoader;

            Current = _Builder.Build();
        }

        public static void StartCurrent()
        {
            if (Current == null)
            {
                throw SorschiaException.AppFailure("Failed to start current app.");
            }

            Current.Start();
        }

        public static void StopCurrent()
        {
            if (Current == null)
            {
                throw SorschiaException.AppFailure("Failed to stop current app.");
            }

            Current.Stop();
        }
    }
}
