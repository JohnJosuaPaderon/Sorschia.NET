using System.Security;

namespace Sorschia.Configurations
{
    public interface IConnectionStringSource
    {
        SecureString this[string key] { get; }
    }
}
