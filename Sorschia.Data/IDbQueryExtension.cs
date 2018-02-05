namespace Sorschia.Data
{
    public static class IDbQueryExtension
    {
        public static IDbQuery AddInParameter(this IDbQuery instance, string parameterName, object value)
        {
            instance.Parameters.AddIn(parameterName, value);
            return instance;
        }

        public static IDbQuery AddInParameter(this IDbQuery instance, string parameterName, DbQueryParameterType type, object value)
        {
            instance.Parameters.AddIn(parameterName, type, value);
            return instance;
        }

        public static IDbQuery AddOutParameter(this IDbQuery instance, string parameterName)
        {
            instance.Parameters.AddOut(parameterName);
            return instance;
        }

        public static IDbQuery AddOutParameter(this IDbQuery instance, string parameterName, DbQueryParameterType type)
        {
            instance.Parameters.AddOut(parameterName, type);
            return instance;
        }

        public static IDbQuery AddInOutParameter(this IDbQuery instance, string parameterName, object value)
        {
            instance.Parameters.AddInOut(parameterName, value);
            return instance;
        }

        public static IDbQuery AddInOutParameter(this IDbQuery instance, string parameterName, DbQueryParameterType type, object value)
        {
            instance.Parameters.AddInOut(parameterName, type, value);
            return instance;
        }
    }
}
