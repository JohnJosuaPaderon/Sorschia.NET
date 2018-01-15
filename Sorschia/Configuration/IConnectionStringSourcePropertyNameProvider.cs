namespace Sorschia.Configuration
{
    public interface IConnectionStringSourcePropertyNameProvider
    {
        string IsEncrypted { get; }
        string ConnectionStrings { get; }
        IConnectionStringPropertyNameProvider ConnectionString { get; }
    }
}
