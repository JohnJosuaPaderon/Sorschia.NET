using Microsoft.Extensions.DependencyInjection;
using Sorschia.Configurations;
using Sorschia.Utilities;
using System;

namespace Sorschia
{
    public sealed class SorschiaApp
    {
        static SorschiaApp()
        {
            Current = new SorschiaApp();
        }

        public static SorschiaApp Current { get; }

        private const string BASE_DIRECTORY_PLACEHOLDER = "<basedir>";

        public static T ResolveService<T>()
        {
            return Current.ServiceProvider.GetService<T>();
        }

        public static string ResolveDirectory(string key)
        {
            return Current.DirectoryProvider[key];
        }

        public static string ResolveFile(string key)
        {
            return Current.FileProvider[key];
        }

        public static void BuildApp(SorschiaBootstrapper bootstrapper)
        {
            var services = new ServiceCollection();
            bootstrapper.ConfigureServices(services);

            if (!string.IsNullOrWhiteSpace(bootstrapper.BaseDirectory))
            {
                DirectoryResolver.ResolveExistence(bootstrapper.BaseDirectory);
            }

            Current.ServiceProvider = services.BuildServiceProvider();
            Current.BaseDirectory = bootstrapper.BaseDirectory;
            Current.DirectoryProvider = new ApplicationDirectoryProvider(Current);
            Current.FileProvider = new ApplicationFileProvider(Current);
        }

        public IServiceProvider ServiceProvider { get; private set; }
        public ApplicationDirectoryProvider DirectoryProvider { get; private set; }
        public ApplicationFileProvider FileProvider { get; private set; }
        public string BaseDirectory { get; private set; }

        public string ResolveRelativePath(string sourcePath)
        {
            if (sourcePath.StartsWith(BASE_DIRECTORY_PLACEHOLDER))
            {
                return sourcePath.Replace(BASE_DIRECTORY_PLACEHOLDER, BaseDirectory);
            }
            else
            {
                return sourcePath;
            }
        }
    }
}
