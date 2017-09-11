using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Sorschia.Data
{
    public interface IDbQueryInfo<TData, TConnection, TCommand, TParameter>
       where TConnection : DbConnection
       where TCommand : DbCommand
       where TParameter : DbParameter
    {
        List<TParameter> Parameters { get; }
        CommandType CommandType { get; set; }
        string CommandText { get; set; }
        TData Data { get; set; }
        IReaderToDataConverter<TData> Converter { get; }
        GetProcessResultDelegate<TData, TCommand> GetProcessResult { get; set; }
        TCommand CreateCommand(TConnection connection);
    }
}
