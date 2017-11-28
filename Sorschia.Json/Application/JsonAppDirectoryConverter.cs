using Newtonsoft.Json.Linq;
using Sorschia.Extensions;

namespace Sorschia.Application
{
    public static class JsonAppDirectoryConverter
    {
        private const string PROPERTY_KEY = "key";
        private const string PROPERTY_IS_REQUIRED = "isRequired";
        private const string PROPERTY_PATH = "path";

        public static JObject Convert(IAppDirectory directory)
        {
            if (directory == null)
            {
                throw SorschiaException.ParameterRequired(nameof(directory));
            }

            var result = new JObject
            {
                { PROPERTY_KEY, directory.Key },
                { PROPERTY_IS_REQUIRED, directory.IsRequired },
                { PROPERTY_PATH, directory.Path }
            };

            return result;
        }

        public static IAppDirectory Convert(JObject jDirectory)
        {
            if (jDirectory == null)
            {
                throw SorschiaException.ParameterRequired(nameof(jDirectory));
            }

            var result = new AppDirectory()
            {
                Key = jDirectory.GetString(PROPERTY_KEY),
                IsRequired = jDirectory.GetBoolean(PROPERTY_IS_REQUIRED),
                Path = jDirectory.GetString(PROPERTY_PATH)
            };

            return result;
        }
    }
}
