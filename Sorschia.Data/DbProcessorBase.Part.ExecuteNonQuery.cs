using Sorschia.Processing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    partial class DbProcessorBase<TCommand>
    {
        public IProcessResult ExecuteNonQuery(IDbQuery query, IProcessContext processContext)
        {
            using (var command = _CommandCreator.Create(query, processContext))
            {
                try
                {
                    command.ExecuteNonQuery();
                    return ProcessResult.Success();
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                try
                {
                    await command.ExecuteNonQueryAsync();
                    return ProcessResult.Success();
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext, CancellationToken cancellationToken)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext, cancellationToken))
            {
                try
                {
                    await command.ExecuteNonQueryAsync(cancellationToken);
                    return ProcessResult.Success();
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult.Failed(ex);
                }
            }
        }
    }
}
