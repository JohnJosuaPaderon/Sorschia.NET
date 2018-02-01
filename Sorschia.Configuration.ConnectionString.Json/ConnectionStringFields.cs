namespace Sorschia.Configuration
{
    internal static class ConnectionStringFields
    {
        static ConnectionStringFields()
        {
            Key = "key";
            Value = "value";
        }

        public static string Key { get; }
        public static string Value { get; }
    }
}
