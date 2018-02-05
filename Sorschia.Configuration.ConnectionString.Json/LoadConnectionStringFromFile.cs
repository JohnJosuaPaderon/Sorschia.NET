using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Sorschia.Configuration
{
    internal sealed partial class LoadConnectionStringFromFile : LoadConnectionStringFromFileBase, ILoadConnectionStringFromFile
    {
        public IConnectionStringCollection Load(string filePath)
        {
            Validate(filePath);
            var content = UnsafeLoadContent(filePath);

            if (string.IsNullOrWhiteSpace(content))
            {
                throw SorschiaConnectionStringException.EmptySource();
            }

            var jArray = Parse(content);

            var result = new ConnectionStringCollection();

            foreach (JObject jObject in jArray)
            {
                result.Add(ConnectionStringConverter.Convert(jObject));
            }

            return result;
        }

        private JArray Parse(string content)
        {
            try
            {
                var parsed = JArray.Parse(content);

                if (parsed != null && parsed.Any())
                {
                    return parsed;
                }
                else
                {
                    throw SorschiaConnectionStringException.ParseError();
                }
            }
            catch (Exception ex)
            {
                throw SorschiaException.ParseError(ex);
            }
        }
    }
}
