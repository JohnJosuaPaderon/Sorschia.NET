namespace Sorschia.Configuration
{
    internal static class ConnectionStringValidator
    {
        public static void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw SorschiaConnectionStringException.InvalidKey();
            }
        }

        public static void ValidateValue(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw SorschiaConnectionStringException.InvalidValue();
            }
        }

        public static void Validate(IConnectionString connectionString)
        {
            if (connectionString == null)
            {
                throw SorschiaConnectionStringException.Invalid();
            }

            ValidateKey(connectionString.Key);
        }
    }
}
