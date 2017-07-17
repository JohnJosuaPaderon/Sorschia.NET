using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Sorschia.Data.Rdbms
{
    public interface IDbQueryInfo<TConnection, TCommand, TParameter>
        where TConnection : DbConnection
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        List<TParameter> Parameters { get; }
        CommandType CommandType { set; get; }
        string CommandText { set; get; }
        GetProcessResultDelegate<TCommand> GetProcessResult { get; set; }
        TCommand CreateCommand(TConnection connection);
    }

    public interface IDbQueryInfo<T, TConnection, TCommand, TParameter>
        where TConnection : DbConnection
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        List<TParameter> Parameters { get; }
        CommandType CommandType { set; get; }
        string CommandText { set; get; }
        T Data { get; set; }
        GetProcessResultDelegate<T, TCommand> GetProcessResult { get; set; }
        TCommand CreateCommand(TConnection connection);
    }

}
