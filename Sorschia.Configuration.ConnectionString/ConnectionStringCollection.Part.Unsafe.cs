using Sorschia.Security;

namespace Sorschia.Configuration
{
    partial class ConnectionStringCollection
    {
        private bool UnsafeContains(string key)
        {
            return _Source.ContainsKey(key);
        }

        private void UnsafeAdd(IConnectionString connectionString)
        {
            _Source.Add(connectionString.Key, connectionString);
        }

        private void UnsafeAdd(string key, string value)
        {
            UnsafeAdd(new ConnectionString(key) { SecureValue = SecureStringConverter.Convert(value) });
        }

        private void UnsafeRemove(string key)
        {
            _Source.Remove(key);
        }
    }
}
