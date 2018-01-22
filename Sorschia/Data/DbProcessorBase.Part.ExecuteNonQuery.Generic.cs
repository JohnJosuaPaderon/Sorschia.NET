using Sorschia.Processing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    partial class DbProcessorBase<TCommand>
    {
        public IProcessResult<T> ExecuteNonQuery<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            using (var command = _CommandCreator.Create(query, processContext))
            {
                try
                {
                    return callback(command, command.ExecuteNonQuery());
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult<T>.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                try
                {
                    return callback(command, await command.ExecuteNonQueryAsync());
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult<T>.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback, CancellationToken cancellationToken)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext, cancellationToken))
            {
                try
                {
                    return callback(command, await command.ExecuteNonQueryAsync(cancellationToken));
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult<T>.Failed(ex);
                }
            }
        }
    }
}
