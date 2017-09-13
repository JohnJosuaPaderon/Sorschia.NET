using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Data
{
    public class AggregateQuery<TParameter> : IAggregateQuery<TParameter>
        where TParameter : IQueryParameter
    {
        public AggregateQuery()
        {
            _Queries = new Queue<IQuery<TParameter>>();
        }

        private readonly Queue<IQuery<TParameter>> _Queries;

        public void Clear()
        {
            _Queries.Clear();
        }

        public IQuery<TParameter> Dequeue()
        {
            return _Queries.Dequeue();
        }

        public void Enqueue(IQuery<TParameter> query)
        {
            _Queries.Enqueue(query);
        }

        public IEnumerator<IQuery<TParameter>> GetEnumerator()
        {
            return _Queries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
