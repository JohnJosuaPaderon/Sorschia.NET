using System.Collections.Generic;

namespace Sorschia.Configuration
{
    public interface IConnectionStringCollection : IEnumerable<IConnectionString>
    {
        string this[string key] { get; set; }
        void Add(string key, string value);
        void Remove(string key);
        void Clear();
    }
}
