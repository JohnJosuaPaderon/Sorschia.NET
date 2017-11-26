using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sorschia
{
    public abstract class SorschiaAppBase : ISorschiaApp
    {
        private const string ERROR_INITIALIZATION = "Creation of multiple instance of Sorschia.SorschiaApp class is not allowed.";
        
        public static ISorschiaApp Current { get; private set; }

        public static T GetService<T>()
        {
            return Current.ServiceProvider.GetService<T>();
        }

        public SorschiaAppBase()
        {
            if (Current != null)
            {
                throw new SorschiaException(ERROR_INITIALIZATION);
            }

            Current = this;
        }

        public IServiceProvider ServiceProvider { get; private set; }
        public string AppDirectory { get; protected set; }

        protected abstract void ConfigureServices(IServiceCollection services);

        public void Build()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
