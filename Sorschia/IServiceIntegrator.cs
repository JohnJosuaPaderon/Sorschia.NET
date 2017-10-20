using Microsoft.Extensions.DependencyInjection;

namespace Sorschia
{
    public interface IServiceIntegrator
    {
        string Key { get; }
        IServiceCollection Integrate(IServiceCollection services);
    }
}
