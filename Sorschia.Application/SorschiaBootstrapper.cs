using Microsoft.Extensions.DependencyInjection;

namespace Sorschia
{
    public abstract class SorschiaBootstrapper
    {
        internal protected virtual void ConfigureServices(IServiceCollection services)
        {
            // TODO: Default services.
        }

        internal protected string BaseDirectory { get; set; }
    }
}
