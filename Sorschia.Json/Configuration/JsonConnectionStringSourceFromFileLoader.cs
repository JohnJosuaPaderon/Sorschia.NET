using Newtonsoft.Json.Linq;
using Sorschia.Extensions;
using System;
using System.IO;

namespace Sorschia.Configuration
{
    public sealed class JsonConnectionStringSourceFromFileLoader : IConnectionStringSourceLoader
    {
        private const string PROPERTY_CONNECTION_STRINGS = "connectionstrings";
        private const string PROPERTY_CONNECTION_STRING_KEY = "key";
        private const string PROPERTY_CONNECTION_STRING_VALUE = "value";

        public JsonConnectionStringSourceFromFileLoader(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        public void Load(IConnectionStringSource connectionStringSource)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                throw SorschiaException.PropertyRequired(nameof(FilePath));
            }
            else if (!File.Exists(FilePath))
            {
                throw SorschiaException.FileNotFound(FilePath);
            }
            else
            {
                JObject jObject = null;
                JArray jConnectionStrings = null;

                try
                {
                    jObject = JObject.Parse(File.ReadAllText(FilePath));
                }
                catch (Exception)
                {
                    throw SorschiaException.ParseError("Failed to parse connection strings from .json file.");
                }

                if (jObject != null)
                {
                    jConnectionStrings = jObject.GetArray(PROPERTY_CONNECTION_STRINGS);
                }

                if (jConnectionStrings != null)
                {
                    foreach (JObject jConnectionString in jConnectionStrings)
                    {
                        connectionStringSource.Add(jConnectionString.GetString(PROPERTY_CONNECTION_STRING_KEY), jConnectionString.GetString(PROPERTY_CONNECTION_STRING_VALUE));
                    }
                }
                else
                {
                    throw SorschiaException.ParseError("Failed to get connection strings section from .json file.");
                }
            }
        }
    }
}
