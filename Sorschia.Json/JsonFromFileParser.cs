using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Sorschia
{
    public sealed class JsonFromFileParser : IJsonFromFileParser
    {
        private void ValidatePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw SorschiaException.ParameterRequired(nameof(filePath));
            }
            else if (!File.Exists(filePath))
            {
                throw SorschiaException.FileNotFound(filePath);
            }
        }

        public JArray ParseArray(string filePath)
        {
            ValidatePath(filePath);

            try
            {
                return JArray.Parse(File.ReadAllText(filePath));
            }
            catch (Exception ex)
            {
                throw SorschiaException.ParseError(ex);
            }
        }

        public JObject ParseObject(string filePath)
        {
            ValidatePath(filePath);

            try
            {
                return JObject.Parse(File.ReadAllText(filePath));
            }
            catch (Exception ex)
            {

                throw SorschiaException.ParseError(ex);
            }
        }
    }
}
