using System.Collections.Generic;
using System.Data.Common;

namespace Sorschia.Data
{
    public class Query<TParameter> : IQuery<TParameter>
        where TParameter : IQueryParameter
    {
        public static Query<TParameter> GetStoredProcedure(string procedure)
        {
            var query = new Query<TParameter>
            {
                CommandText = procedure,
                Type = QueryType.ProcedureCall
            };

            return query;
        }

        public Query()
        {
            Parameters = new QueryParameterCollection<TParameter>();
            BindingSource = new Dictionary<string, object>();
        }

        public string CommandText { get; set; }
        public QueryType Type { get; set; }
        public string ConnectionStringKey { get; set; }
        public Dictionary<string, object> BindingSource { get; set; }
        public IQueryParameterCollection<TParameter> Parameters { get; }

        public static bool operator ==(Query<TParameter> left, Query<TParameter> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Query<TParameter> left, Query<TParameter> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as Query<TParameter>;
            return
                CommandText.Equals(value.CommandText) ^
                Type.Equals(value.Type);
        }

        public override int GetHashCode()
        {
            return
                CommandText.GetHashCode() ^
                Type.GetHashCode();
        }

        public override string ToString()
        {
            return CommandText;
        }
    }

    public class Query<TCommand, TParameter> : IQuery<TCommand, TParameter>
        where TCommand : DbCommand
        where TParameter : IQueryParameter
    {
        public static Query<TCommand, TParameter> GetStoredProcedure(string procedure, GetProcessResultDelegate<TCommand> getProcessResultCallback)
        {
            var query = new Query<TCommand, TParameter>
            {
                CommandText = procedure,
                Type = QueryType.ProcedureCall,
                GetProcessResultCallback = getProcessResultCallback
            };

            return query;
        }

        public Query()
        {
            Parameters = new QueryParameterCollection<TParameter>();
            BindingSource = new Dictionary<string, object>();
        }

        public string CommandText { get; set; }
        public QueryType Type { get; set; }
        public string ConnectionStringKey { get; set; }
        public Dictionary<string, object> BindingSource { get; set; }
        public GetProcessResultDelegate<TCommand> GetProcessResultCallback { get; set; }
        public IQueryParameterCollection<TParameter> Parameters { get; }

        public static bool operator ==(Query<TCommand, TParameter> left, Query<TCommand, TParameter> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Query<TCommand, TParameter> left, Query<TCommand, TParameter> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as Query<TCommand, TParameter>;
            return
                CommandText.Equals(value.CommandText) ^
                Type.Equals(value.Type);
        }

        public override int GetHashCode()
        {
            return
                CommandText.GetHashCode() ^
                Type.GetHashCode();
        }

        public override string ToString()
        {
            return CommandText;
        }
    }

    public class Query<TData, TCommand, TParameter> : IQuery<TData, TCommand, TParameter>
        where TCommand : DbCommand
        where TParameter : IQueryParameter
    {
        public static Query<TData, TCommand, TParameter> GetStoredProcedure(string procedure, GetProcessResultDelegate<TData, TCommand> getProcessResultCallback)
        {
            var query = new Query<TData, TCommand, TParameter>
            {
                CommandText = procedure,
                Type = QueryType.ProcedureCall,
                GetProcessResultCallback = getProcessResultCallback
            };

            return query;
        }

        public Query()
        {
            Parameters = new QueryParameterCollection<TParameter>();
            BindingSource = new Dictionary<string, object>();
        }

        public string CommandText { get; set; }
        public QueryType Type { get; set; }
        public string ConnectionStringKey { get; set; }
        public Dictionary<string, object> BindingSource { get; set; }
        public GetProcessResultDelegate<TData, TCommand> GetProcessResultCallback { get; set; }
        public IQueryParameterCollection<TParameter> Parameters { get; }

        public static bool operator ==(Query<TData, TCommand, TParameter> left, Query<TData, TCommand, TParameter> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Query<TData, TCommand, TParameter> left, Query<TData, TCommand, TParameter> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as Query<TData, TCommand, TParameter>;
            return
                CommandText.Equals(value.CommandText) ^
                Type.Equals(value.Type);
        }

        public override int GetHashCode()
        {
            return
                CommandText.GetHashCode() ^
                Type.GetHashCode();
        }

        public override string ToString()
        {
            return CommandText;
        }
    }
}
