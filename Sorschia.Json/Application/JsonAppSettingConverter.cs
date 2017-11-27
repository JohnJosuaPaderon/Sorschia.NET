using Newtonsoft.Json.Linq;
using Sorschia.Extensions;

namespace Sorschia.Application
{
    public static class JsonAppSettingConverter
    {
        private const string PROPERTY_KEY = "key";
        private const string PROPERTY_VALUE = "value";

        public static JObject Convert(IAppSetting setting)
        {
            if (setting == null)
            {
                throw SorschiaException.ParameterRequired(nameof(setting));
            }

            var result = new JObject
            {
                { PROPERTY_KEY, setting.Key },
                { PROPERTY_VALUE, setting.Value }
            };

            return result;
        }

        public static IAppSetting Convert(JObject jSetting)
        {
            if (jSetting == null)
            {
                throw SorschiaException.ParameterRequired(nameof(jSetting));
            }

            var result = new AppSetting()
            {
                Key = jSetting.GetString(PROPERTY_KEY),
                Value = jSetting.GetString(PROPERTY_VALUE)
            };

            return result;
        }
    }
}
