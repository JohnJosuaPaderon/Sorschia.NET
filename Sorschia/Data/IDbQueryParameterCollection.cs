using System.Collections.Generic;

namespace Sorschia.Data
{
    public interface IDbQueryParameterCollection : IEnumerable<IDbQueryParameter>
    {
        IDbQueryParameter this[string parameterName] { get; }

        void Add(IDbQueryParameter parameter);
        void Remove(IDbQueryParameter parameter);
        void Remove(string parameterName);
        void Clear();
    }
}
