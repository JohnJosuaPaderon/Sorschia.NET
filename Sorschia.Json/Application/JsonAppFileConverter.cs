using Newtonsoft.Json.Linq;
using Sorschia.Extensions;

namespace Sorschia.Application
{
    public static class JsonAppFileConverter
    {
        private const string PROPERTY_TYPE = "type";
        private const string PROPERTY_IS_REQUIRED = "isRequired";
        private const string PROPERTY_PATH = "path";

        public static JObject Convert(IAppFile file)
        {
            if (file == null)
            {
                throw SorschiaException.ParameterRequired(nameof(file));
            }

            var result = new JObject
            {
                { PROPERTY_TYPE, file.Type.ToString() },
                { PROPERTY_IS_REQUIRED, file.IsRequired },
                { PROPERTY_PATH, file.Path }
            };

            return result;
        }

        public static IAppFile Convert(JObject jFile)
        {
            if (jFile == null)
            {
                throw SorschiaException.ParameterRequired(nameof(jFile));
            }

            var result = new AppFile(AppFileTypeParser.Parse(jFile.GetString(PROPERTY_TYPE)))
            {
                IsRequired = jFile.GetBoolean(PROPERTY_IS_REQUIRED),
                Path = jFile.GetString(PROPERTY_PATH)
            };

            return result;
        }
    }
}
