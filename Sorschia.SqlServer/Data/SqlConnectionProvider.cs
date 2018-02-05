﻿using Sorschia.Data.Processing;
using Sorschia.Processing;
using System;
using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlConnectionProvider : DbConnectionProviderBase<SqlConnection>, IDbConnectionProvider<SqlConnection>
    {
        //public SqlConnectionProvider(IConnectionStringSource connectionStringSource)
        //{
        //    _ConnectionStringSource = connectionStringSource;
        //}

        //private readonly IConnectionStringSource _ConnectionStringSource;

        protected override SqlConnection Instantiate(IProcessContext processContext)
        {
            if (processContext is DbProcessContext dbProcessContext)
            {
                throw new NotImplementedException();
                // return new SqlConnection(_ConnectionStringSource[dbProcessContext.ConnectionStringKey]);
            }
            else
            {
                throw SorschiaException.InvalidOperation($"Type of '{typeof(DbProcessContext).FullName}' is expected.");
            }
        }
    }
}
