using Newtonsoft.Json.Linq;
using Sorschia.Extensions;

namespace Sorschia.Configuration
{
    public sealed class JsonConnectionStringSourceFromFileLoader : ConnectionStringFromFileLoaderBase, IConnectionStringSourceLoader
    {
        public JsonConnectionStringSourceFromFileLoader(
            IConnectionStringFileSource source,
            IConnectionStringSourcePropertyNameProvider connectionStringProperties,
            IJsonFromFileParser parser) : base(source)
        {
            _Properties = connectionStringProperties;
            _Parser = parser;
        }
        
        private readonly IConnectionStringSourcePropertyNameProvider _Properties;
        private readonly IJsonFromFileParser _Parser;

        public void Load(IConnectionStringSource connectionStringSource)
        {
            ValidateSource();

            JObject jObject = _Parser.ParseObject(_Source.FilePath);
            JArray jConnectionStrings = null;

            if (jObject != null)
            {
                connectionStringSource.IsEncrypted = jObject.GetBoolean(_Properties.IsEncrypted);
                jConnectionStrings = jObject.GetArray(_Properties.ConnectionStrings);
            }

            if (jConnectionStrings != null)
            {
                foreach (JObject jConnectionString in jConnectionStrings)
                {
                    connectionStringSource.Add(jConnectionString.GetString(_Properties.ConnectionString.Key), jConnectionString.GetString(_Properties.ConnectionString.Value));
                }
            }
            else
            {
                throw SorschiaException.ParseError("Failed to get connection strings section from .json file.");
            }
        }
    }
}
