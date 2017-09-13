using Sorschia.Data;

namespace Sorschia.Extensions
{
    public static class IQueryParameterCollectionExtension
    {
        public static void AddIn(this IQueryParameterCollection<IQueryParameter> instance, string name, object value)
        {
            instance.Add(new QueryParameter(name)
            {
                Value = value,
                Direction = QueryParameterDirection.In
            });
        }

        public static void AddOut(this IQueryParameterCollection<IQueryParameter> instance, string name)
        {
            instance.Add(new QueryParameter(name)
            {
                Value = null,
                Direction = QueryParameterDirection.Out
            });
        }

        public static void AddInOut(this IQueryParameterCollection<IQueryParameter> instance, string name, object value)
        {
            instance.Add(new QueryParameter(name)
            {
                Value = value,
                Direction = QueryParameterDirection.InOut
            });
        }
    }
}
