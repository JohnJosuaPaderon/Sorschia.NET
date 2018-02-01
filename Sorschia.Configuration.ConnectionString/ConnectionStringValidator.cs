namespace Sorschia.Configuration
{
    internal static class ConnectionStringValidator
    {
        public static void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw SorschiaException.ValidationFailed("Failed to validate Connection String Key.");
            }
        }

        public static void ValidateValue(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw SorschiaException.ValidationFailed("Failed to validate Connection String.");
            }
        }

        public static void Validate(IConnectionString connectionString)
        {
            if (connectionString == null)
            {
                throw SorschiaException.ValidationFailed("Failed to validate Connection String.");
            }

            ValidateKey(connectionString.Key);
        }
    }
}
