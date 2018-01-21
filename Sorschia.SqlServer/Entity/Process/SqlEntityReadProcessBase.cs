using Sorschia.Data;
using Sorschia.Entity.Converter;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity.Process
{
    public abstract class SqlEntityReadProcessBase<T, TIdentifier, TConverter> : SqlEntityProcessBase, IProcess<T>
        where T : IEntity<TIdentifier>
        where TConverter : IEntityConverter<T, TIdentifier>
    {
        public SqlEntityReadProcessBase(IDbProcessor<SqlCommand> processor, TConverter converter, string schema = null) : base(processor, schema)
        {
            _Converter = converter;
        }

        private readonly TConverter _Converter;

        protected virtual void PrepareConverter(TConverter converter)
        {
            // TODO:
        }

        public IProcessResult<T> Execute(IProcessContext context)
        {
            PrepareConverter(_Converter);
            return _Processor.ExecuteReader(Query, context, _Converter);
        }

        public Task<IProcessResult<T>> ExecuteAsync(IProcessContext context)
        {
            PrepareConverter(_Converter);
            return _Processor.ExecuteReaderAsync(Query, context, _Converter);
        }

        public Task<IProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken)
        {
            PrepareConverter(_Converter);
            return _Processor.ExecuteReaderAsync(Query, context, _Converter, cancellationToken);
        }
    }
}
