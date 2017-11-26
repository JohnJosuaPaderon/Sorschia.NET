using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Application
{
    public interface IServiceIntegrator
    {
        string Key { get; }
        IServiceCollection Integrate(IServiceCollection services);
    }
}
