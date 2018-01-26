using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Application
{
    public interface IServiceIntegrator
    {
        string Key { get; }
        string[] Tags { get; }
        void Integrate(IServiceCollection services);
    }
}
