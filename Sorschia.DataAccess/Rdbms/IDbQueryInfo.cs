using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Sorschia.DataAccess.Rdbms
{
    public interface IDbQueryInfo<TCommand, TParameter>
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        List<TParameter> Parameters { get; }
        CommandType CommandType { get; set; }
        string CommandText { get; set; }
        Func<TCommand, IProcessResult> GetProcessResult { get; set; }
    }
}
