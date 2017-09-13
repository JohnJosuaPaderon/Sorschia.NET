using System.Collections.Generic;

namespace Sorschia.Data
{
    public interface IAggregateQuery<TParameter> : IEnumerable<IQuery<TParameter>>
        where TParameter : IQueryParameter
    {
        void Enqueue(IQuery<TParameter> query);
        IQuery<TParameter> Dequeue();
        void Clear();
    }
}
