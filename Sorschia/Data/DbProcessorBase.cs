using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract class DbProcessorBase<TCommand> : IDbProcessor<TCommand>
        where TCommand : DbCommand
    {
        public DbProcessorBase(IDbCommandCreator<TCommand> commandCreator)
        {
            _CommandCreator = commandCreator;
        }

        private readonly IDbCommandCreator<TCommand> _CommandCreator;

        public IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult ExecuteNonQuery(IDbQuery query, IProcessContext processContext)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<T> ExecuteNonQuery<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<T> ExecuteReader<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<T> ExecuteScalar<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
