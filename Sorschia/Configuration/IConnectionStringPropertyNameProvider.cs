namespace Sorschia.Configuration
{
    public interface IConnectionStringPropertyNameProvider
    {
        string Key { get; }
        string Value { get; }
    }
}
