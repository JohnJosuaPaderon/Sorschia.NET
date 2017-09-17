namespace Sorschia.Configurations
{
    public interface IConnectionStringSource
    {
        string this[string key] { get; }

        void Add(string key, string connectionString);
        void Remove(string key);
        void Update(string key, string connectionString);
    }
}
