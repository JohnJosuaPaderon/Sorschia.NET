using System.Data.Common;

namespace Sorschia.Data
{
    public interface IDbCommandProvider<TCommand> where TCommand : DbCommand
    {
        TCommand Create<TParameter>(IQuery<TParameter> query)
            where TParameter : IQueryParameter;
        IAggregateDbCommand<TCommand> Create<TParameter>(IAggregateQuery<TParameter> aggregateQuery)
            where TParameter : IQueryParameter;
    }
}
