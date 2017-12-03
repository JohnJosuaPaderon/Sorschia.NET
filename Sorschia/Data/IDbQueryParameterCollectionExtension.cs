namespace Sorschia.Data
{
    public static class IDbQueryParameterCollectionExtension
    {
        public static void AddIn(this IDbQueryParameterCollection instance, string parameterName, object value)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.In, DbQueryParameterType.NotSet, value));
        }

        public static void AddIn(this IDbQueryParameterCollection instance, string parameterName, DbQueryParameterType type, object value)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.In, type, value));
        }

        public static void AddOut(this IDbQueryParameterCollection instance, string parameterName)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.Out, DbQueryParameterType.NotSet, null));
        }
        
        public static void AddOut(this IDbQueryParameterCollection instance, string parameterName, DbQueryParameterType type)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.Out, type, null));
        }

        public static void AddInOut(this IDbQueryParameterCollection instance, string parameterName, object value)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.InOut, DbQueryParameterType.NotSet, value));
        }

        public static void AddInOut(this IDbQueryParameterCollection instance, string parameterName, DbQueryParameterType type, object value)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.InOut, type, value));
        }
    }
}
