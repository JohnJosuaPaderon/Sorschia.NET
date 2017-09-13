namespace Sorschia.Data
{
    public class QueryParameter : IQueryParameter
    {
        public QueryParameter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new SorschiaException(SorschiaExceptionType.InvalidQueryParameterName);
            }
        }

        public string Name { get; }
        public object Value { get; set; }
        public bool BindToSource { get; set; }
        public string BindingKey { get; set; }
        public QueryParameterDirection Direction { get; set; }

        public static bool operator ==(QueryParameter left, QueryParameter right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(QueryParameter left, QueryParameter right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as QueryParameter;
            return Name.Equals(value.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
