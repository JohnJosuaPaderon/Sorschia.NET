using Microsoft.Extensions.DependencyInjection;
using Sorschia.Extensions;

namespace Sorschia
{
    public abstract class SorschiaBootstrapper
    {
        internal protected virtual void ConfigureServices(IServiceCollection services)
        {
            services.UseDefaultStringBuilders();
        }

        internal protected string BaseDirectory { get; set; }
    }
}
