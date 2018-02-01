using System.Security;

namespace Sorschia.Configuration
{
    public interface IConnectionString
    {
        string Key { get; }
        SecureString SecureValue { get; set; }
    }
}
