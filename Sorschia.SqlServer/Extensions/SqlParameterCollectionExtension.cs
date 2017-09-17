using System.Data;
using System.Data.SqlClient;

namespace Sorschia.Extensions
{
    public static class SqlParameterCollectionExtension
    {
        private static SqlParameter Instantiate(string name, object value, ParameterDirection direction)
        {
            return new SqlParameter()
            {
                ParameterName = name,
                Value = value,
                Direction = direction
            };
        }

        public static void AddIn(this SqlParameterCollection instance, string name, object value)
        {
            instance.Add(Instantiate(name, value, ParameterDirection.Input));
        }

        public static void AddOut(this SqlParameterCollection instance, string name)
        {
            instance.Add(Instantiate(name, null, ParameterDirection.Output));
        }

        public static void AddInOut(this SqlParameterCollection instance, string name, object value)
        {
            instance.Add(Instantiate(name, value, ParameterDirection.InputOutput));
        }
    }
}
