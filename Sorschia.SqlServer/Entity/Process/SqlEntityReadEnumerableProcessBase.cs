using Sorschia.Data;
using Sorschia.Entity.Converter;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity.Process
{
    public abstract class SqlEntityReadEnumerableProcessBase<T, TIdentifier, TConverter> : SqlEntityProcessBase, IEnumerableProcess<T>
        where TConverter : IEntityConverter<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public SqlEntityReadEnumerableProcessBase(IDbProcessor<SqlCommand> processor, TConverter converter, string schema = null) : base(processor, schema)
        {
            _Converter = converter;
        }

        private readonly TConverter _Converter;

        protected virtual void PrepareConverter(TConverter converter)
        {
            // TODO: Prepare the Converter proeprties.
        }

        public IEnumerableProcessResult<T> Execute(IProcessContext context)
        {
            PrepareConverter(_Converter);
            return _Processor.ExecuteEnumerableReader(Query, context, _Converter);
        }

        public Task<IEnumerableProcessResult<T>> ExecuteAsync(IProcessContext context)
        {
            PrepareConverter(_Converter);
            return _Processor.ExecuteEnumerableReaderAsync(Query, context, _Converter);
        }

        public Task<IEnumerableProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken)
        {
            PrepareConverter(_Converter);
            return _Processor.ExecuteEnumerableReaderAsync(Query, context, _Converter, cancellationToken);
        }
    }
}
