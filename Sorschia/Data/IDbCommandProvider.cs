using System.Data.Common;

namespace Sorschia.Data
{
    public interface IDbCommandProvider<TConnection, TTransaction, TCommand>
        where TConnection : DbConnection
        where TCommand : DbCommand
    {
        TCommand Create<TParameter>(TConnection connection, IQuery<TParameter> query)
            where TParameter : IQueryParameter;

        TCommand Create<TParameter>(TConnection connection, TTransaction transaction, IQuery<TParameter> query)
            where TParameter : IQueryParameter;
    }
}
