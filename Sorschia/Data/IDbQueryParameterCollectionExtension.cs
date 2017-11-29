namespace Sorschia.Data
{
    public static class IDbQueryParameterCollectionExtension
    {
        public static void AddIn(this IDbQueryParameterCollection instance, string parameterName, object value)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.In, value));
        }

        public static void AddOut(this IDbQueryParameterCollection instance, string parameterName)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.Out, null));
        }

        public static void AddInOut(this IDbQueryParameterCollection instance, string parameterName, object value)
        {
            instance.Add(new DbQueryParameter(parameterName, DbQueryParameterDirection.InOut, value));
        }
    }
}
