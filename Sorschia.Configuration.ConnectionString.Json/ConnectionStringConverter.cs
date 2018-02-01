using Newtonsoft.Json.Linq;
using Sorschia.Extensions;
using Sorschia.Utilities;

namespace Sorschia.Configuration
{
    internal static class ConnectionStringConverter
    {
        public static IConnectionString Convert(JObject jObject)
        {
            if (jObject != null)
            {
                return new ConnectionString(jObject.GetString(ConnectionStringFields.Key))
                {
                    SecureValue = SecureStringConverter.Convert(jObject.GetString(ConnectionStringFields.Value))
                };
            }
            else
            {
                return null;
            }
        }

        public static JObject Convert(IConnectionString connectionString)
        {
            if (connectionString != null)
            {
                return new JObject
                {
                    { ConnectionStringFields.Key, connectionString.Key },
                    { ConnectionStringFields.Value, SecureStringConverter.Convert(connectionString.SecureValue) }
                };
            }
            else
            {
                return null;
            }
        }
    }
}
