using Sorschia.Data;
using Sorschia.Entity.Converter;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity.Process
{
    public abstract class SqlEntityReadProcessBase<T, TIdentifier> : SqlEntityProcessBase, IProcess<T>
        where T : IEntity<TIdentifier>
    {
        public SqlEntityReadProcessBase(IDbProcessor<SqlCommand> processor, IEntityConverter<T, TIdentifier> converter, string schema = null) : base(processor, schema)
        {
            _Converter = converter;
        }

        private readonly IEntityConverter<T, TIdentifier> _Converter;

        public IProcessResult<T> Execute(IProcessContext context)
        {
            return _Processor.ExecuteReader(Query, context, _Converter);
        }

        public Task<IProcessResult<T>> ExecuteAsync(IProcessContext context)
        {
            return _Processor.ExecuteReaderAsync(Query, context, _Converter);
        }

        public Task<IProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken)
        {
            return _Processor.ExecuteReaderAsync(Query, context, _Converter, cancellationToken);
        }
    }
}
