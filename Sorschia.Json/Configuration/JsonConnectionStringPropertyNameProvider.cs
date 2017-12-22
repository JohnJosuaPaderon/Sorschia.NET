namespace Sorschia.Configuration
{
    public sealed class JsonConnectionStringPropertyNameProvider : IConnectionStringPropertyNameProvider
    {
        public JsonConnectionStringPropertyNameProvider()
        {
            Key = "key";
            Value = "value";
        }

        public string Key { get; }
        public string Value { get; }
    }
}
