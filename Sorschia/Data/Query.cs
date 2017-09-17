using System.Collections.Generic;
using System.Data.Common;

namespace Sorschia.Data
{
    public class Query<TParameter> : IQuery<TParameter>
        where TParameter : IQueryParameter
    {
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

    public class Query<TCommand, TParameter> : Query<TParameter>, IQuery<TCommand, TParameter>
        where TCommand : DbCommand
        where TParameter : IQueryParameter
    {
        public GetProcessResultDelegate<TCommand> GetProcessResultCallback { get; set; }
    }

    public class Query<TData, TCommand, TParameter> : Query<TParameter>, IQuery<TData, TCommand, TParameter>
        where TCommand : DbCommand
        where TParameter : IQueryParameter
    {
        public GetProcessResultDelegate<TData, TCommand> GetProcessResultCallback { get; set; }
    }
}
