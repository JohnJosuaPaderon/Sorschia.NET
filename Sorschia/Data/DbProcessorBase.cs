using Sorschia.Processing;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract class DbProcessorBase<TConnection, TCommand> : IDbProcessor<TCommand>
        where TConnection : DbConnection
        where TCommand : DbCommand
    {
        public DbProcessorBase(IDbConnectionProvider<TConnection> connectionProvider)
        {
            _ConnectionProvider = connectionProvider;
        }

        private readonly IDbConnectionProvider<TConnection> _ConnectionProvider;

        public IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            using (command)
            {
                command.Connection = _ConnectionProvider.Establish(processContext);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return converter.EnumerableFromReader(reader);
                    }
                    else
                    {
                        return EnumerableProcessResult<T>.NoResult();
                    }
                }
            }
        }

        public Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public IProcessResult ExecuteNonQuery(TCommand command, IProcessContext processContext)
        {
            throw new System.NotImplementedException();
        }

        public IProcessResult<T> ExecuteNonQuery<T>(TCommand command, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult> ExecuteNonQueryAsync(TCommand command, IProcessContext processContext)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TCommand command, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult> ExecuteNonQueryAsync(TCommand command, IProcessContext processContext, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TCommand command, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public IProcessResult<T> ExecuteReader<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public IProcessResult<T> ExecuteScalar<T>(TCommand command, IProcessContext processContext, System.Func<object, T> converter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteScalarAsync<T>(TCommand command, IProcessContext processContext, System.Func<object, T> converter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteScalarAsync<T>(TCommand command, IProcessContext processContext, System.Func<object, T> converter, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
