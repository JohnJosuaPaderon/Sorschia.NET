using Sorschia.Data;
using Sorschia.Entity.Converter;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity.Process
{
    public abstract class SqlEntityReadEnumerableProcessBase<T, TIdentifier> : SqlEntityProcessBase, IEnumerableProcess<T>
        where T : IEntity<TIdentifier>
    {
        public SqlEntityReadEnumerableProcessBase(IDbProcessor<SqlCommand> processor, IEntityConverter<T, TIdentifier> converter, string schema = null) : base(processor, schema)
        {
            _Converter = converter;
        }

        private readonly IEntityConverter<T, TIdentifier> _Converter;

        public IEnumerableProcessResult<T> Execute(IProcessContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerableProcessResult<T>> ExecuteAsync(IProcessContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerableProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
