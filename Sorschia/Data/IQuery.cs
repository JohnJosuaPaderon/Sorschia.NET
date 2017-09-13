using System.Data.Common;

namespace Sorschia.Data
{
    public interface IQuery<TParameter>
        where TParameter : IQueryParameter
    {
        string CommandText { get; set; }
        QueryType Type { get; set; }
        string ConnectionStringKey { get; set; }
        IQueryParameterCollection<TParameter> Parameters { get; }
    }

    public interface IQuery<TCommand, TParameter> : IQuery<TParameter>
        where TCommand : DbCommand
        where TParameter : IQueryParameter
    {
        GetProcessResultDelegate<TCommand> GetProcessResultCallback { get; set; }
    }

    public interface IQuery<TData, TCommand, TParameter> : IQuery<TParameter>
        where TCommand : DbCommand
        where TParameter : IQueryParameter
    {
        GetProcessResultDelegate<TData, TCommand> GetProcessResultCallback { get; set; }
    }
}
