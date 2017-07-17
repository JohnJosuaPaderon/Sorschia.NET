using Microsoft.Extensions.DependencyInjection;

namespace Sorschia
{
    public interface IApplicationData
    {
        IServiceCollection Services { get; }
    }
}