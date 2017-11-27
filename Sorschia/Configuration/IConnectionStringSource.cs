namespace Sorschia.Configuration
{
    public interface IConnectionStringSource
    {
        void Initialize();
        string this[string key] { get; set; }
        void Add(string key, string connectionString);
        void Remove(string key);
        void Clear();
    }
}
