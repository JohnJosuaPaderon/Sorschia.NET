using System.Security;

namespace Sorschia.Configuration
{
    public sealed class ConnectionString : IConnectionString
    {
        public ConnectionString(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw SorschiaException.ParameterRequired(nameof(key));
            }

            Key = key;
        }

        public string Key { get; }
        public SecureString SecureValue { get; set; }
    }
}
