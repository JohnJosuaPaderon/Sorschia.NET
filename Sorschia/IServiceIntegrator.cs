using Microsoft.Extensions.DependencyInjection;

namespace Sorschia
{
    public interface IServiceIntegrator
    {
        IServiceCollection Integrate(IServiceCollection services);
    }
}
