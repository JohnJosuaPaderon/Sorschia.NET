using Sorschia.Extensions;
using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlCommandProvider : IDbCommandProvider<SqlConnection, SqlTransaction, SqlCommand>
    {
        private static void GetParameters<TParameter>(IQuery<TParameter> query, SqlCommand command) where TParameter : IQueryParameter
        {
            foreach (var parameter in query.Parameters)
            {
                if (parameter.BindToSource)
                {
                    parameter.Value = query.BindingSource[parameter.BindingKey];
                }

                switch (parameter.Direction)
                {
                    case QueryParameterDirection.In:
                        command.Parameters.AddIn(parameter.Name, parameter.Value);
                        break;
                    case QueryParameterDirection.Out:
                        command.Parameters.AddOut(parameter.Name);
                        break;
                    case QueryParameterDirection.InOut:
                        command.Parameters.AddInOut(parameter.Name, parameter.Value);
                        break;
                }
            }
        }

        public SqlCommand Create<TParameter>(SqlConnection connection, IQuery<TParameter> query)
            where TParameter : IQueryParameter
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = query.CommandText,
                CommandType = QueryTypeConverter.ToCommandType(query.Type)
            };

            GetParameters(query, command);

            return command;
        }

        public SqlCommand Create<TParameter>(SqlConnection connection, SqlTransaction transaction, IQuery<TParameter> query)
            where TParameter : IQueryParameter
        {
            var command = new SqlCommand
            {
                Connection = connection,
                Transaction = transaction,
                CommandText = query.CommandText,
                CommandType = QueryTypeConverter.ToCommandType(query.Type)
            };

            GetParameters(query, command);

            return command;
        }
    }
}
