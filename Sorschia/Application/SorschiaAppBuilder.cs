﻿using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Application
{
    internal sealed class SorschiaAppBuilder
    {
        public ISorschiaBootstrapper Bootstrapper { get; set; }
        public IAppConfigurationLoader ConfigurationLoader { get; set; }

        public ISorschiaApp Build()
        {
            if (Bootstrapper == null)
            {
                throw SorschiaException.PropertyRequired(nameof(Bootstrapper));
            }

            ConfigurationLoader.Initialize(Bootstrapper.ConfigurationFilePath);

            var serviceProvider = Bootstrapper.Services.BuildServiceProvider();
            var directories = ConfigurationLoader.GetDirectories();
            var files = ConfigurationLoader.GetFiles();
            var settings = ConfigurationLoader.GetSettings();

            return new SorschiaApp(serviceProvider, directories, files, settings);
        }
    }
}