using System.Collections.Generic;

namespace Sorschia.Data
{
    public interface IQueryParameterCollection<T> : IEnumerable<T>
        where T : IQueryParameter
    {
        T this[string name] { get; set; }
        void Add(T parameter);
        void Remove(string parameterName);
        void Remove(T parameter);
        bool Exists(T parameter);
        bool Exists(string parameterName);
        void Clear();
    }
}
