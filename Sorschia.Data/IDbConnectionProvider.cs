﻿using Sorschia.Processing;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbConnectionProvider<TConnection>
        where TConnection : DbConnection
    {
        TConnection Request(IProcessContext processContext);
        void CloseDispose(IProcessContext processContext);
        TConnection Establish(IProcessContext processContext);
        Task<TConnection> EstablishAsync(IProcessContext processContext);
        Task<TConnection> EstablishAsync(IProcessContext processContext, CancellationToken cancellationToken);
    }
}
