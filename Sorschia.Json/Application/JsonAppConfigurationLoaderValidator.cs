using Newtonsoft.Json.Linq;

namespace Sorschia.Application
{
    public sealed class JsonAppConfigurationLoaderValidator : IAppConfigurationLoaderValidator
    {
        static JsonAppConfigurationLoaderValidator()
        {
            Instance = new JsonAppConfigurationLoaderValidator();
        }

        public static JsonAppConfigurationLoaderValidator Instance { get; }

        public void ValidateSource(JObject source)
        {
            if (source == null)
            {
                throw SorschiaException.PropertyRequired(nameof(source));
            }
            else if (!source.HasValues)
            {
                throw SorschiaException.EmptyCollection(nameof(source));
            }
        }
    }
}
