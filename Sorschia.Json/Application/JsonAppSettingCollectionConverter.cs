using Newtonsoft.Json.Linq;
using System.Linq;

namespace Sorschia.Application
{
    public static class JsonAppSettingCollectionConverter
    {
        public static JArray Convert(IAppSettingCollection settings)
        {
            if (settings == null)
            {
                throw SorschiaException.ParameterRequired(nameof(settings));
            }
            else if (!settings.Any())
            {
                throw SorschiaException.EmptyCollection(nameof(settings));
            }

            var result = new JArray();

            foreach (var setting in settings)
            {
                result.Add(JsonAppSettingConverter.Convert(setting));
            }

            return result;
        }

        public static IAppSettingCollection Convert(JArray jSettings)
        {
            if (jSettings == null)
            {
                throw SorschiaException.ParameterRequired(nameof(jSettings));
            }
            else if (!jSettings.Any())
            {
                throw SorschiaException.EmptyCollection(nameof(jSettings));
            }

            var result = new AppSettingCollection();

            foreach (JObject jSetting in jSettings)
            {
                result.Add(JsonAppSettingConverter.Convert(jSetting));
            }

            return result;
        }
    }
}
