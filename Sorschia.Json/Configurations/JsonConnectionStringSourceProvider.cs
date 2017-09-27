using Newtonsoft.Json.Linq;

namespace Sorschia.Configurations
{
    public class JsonConnectionStringSourceProvider
    {
        public static JsonConnectionStringSourceProvider FromFile(string filePath)
        {
            return new JsonConnectionStringSourceProvider(JsonConnectionStringSourceMode.FromFile, filePath, null);
        }

        public static JsonConnectionStringSourceProvider FromDirectObject(JObject source)
        {
            return new JsonConnectionStringSourceProvider(JsonConnectionStringSourceMode.DirectObject, null, source);
        }

        private static string GetModeErrorMessage(JsonConnectionStringSourceMode mode)
        {
            return $"Mode is set to {mode}.";
        }

        private JsonConnectionStringSourceProvider(JsonConnectionStringSourceMode mode, string filePath, JObject source)
        {
            Mode = mode;
            _FilePath = filePath;
            _Source = source;
        }

        private string _FilePath;
        private JObject _Source;

        public JsonConnectionStringSourceMode Mode { get; }
        public string FilePath
        {
            get
            {
                if (Mode == JsonConnectionStringSourceMode.FromFile)
                {
                    return _FilePath;
                }
                else
                {
                    throw new SorschiaException(GetModeErrorMessage(JsonConnectionStringSourceMode.FromFile), SorschiaExceptionType.AccessDenied);
                }
            }
        }
        public JObject Source
        {
            get
            {
                if (Mode == JsonConnectionStringSourceMode.DirectObject)
                {
                    return _Source;
                }
                else
                {
                    throw new SorschiaException(GetModeErrorMessage(JsonConnectionStringSourceMode.DirectObject), SorschiaExceptionType.AccessDenied);
                }
            }
        }
    }
}
