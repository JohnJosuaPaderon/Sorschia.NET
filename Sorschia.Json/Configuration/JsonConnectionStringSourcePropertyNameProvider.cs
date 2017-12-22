namespace Sorschia.Configuration
{
    public sealed class JsonConnectionStringSourcePropertyNameProvider : IConnectionStringSourcePropertyNameProvider
    {
        public JsonConnectionStringSourcePropertyNameProvider(IConnectionStringPropertyNameProvider connectionString)
        {
            IsEncrypted = "isEncrypted";
            ConnectionStrings = "connectionStrings";
            ConnectionString = connectionString;
        }

        public string IsEncrypted { get; }
        public string ConnectionStrings { get; }
        public IConnectionStringPropertyNameProvider ConnectionString { get; }
    }
}
