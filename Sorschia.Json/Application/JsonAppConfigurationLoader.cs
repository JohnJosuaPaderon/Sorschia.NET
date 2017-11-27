using Newtonsoft.Json.Linq;
using Sorschia.Extensions;
using System;
using System.IO;
using System.Linq;

namespace Sorschia.Application
{
    public sealed class JsonAppConfigurationLoader : IAppConfigurationLoader
    {
        private const string PROPERTY_DIRECTORIES = "directories";
        private const string PROPERTY_FILES = "files";
        private const string PROPERTY_SETTINGS = "settings";

        static JsonAppConfigurationLoader()
        {
            Instance = new JsonAppConfigurationLoader();
        }

        public static JsonAppConfigurationLoader Instance { get; }

        private JsonAppConfigurationLoader()
        {
            _Validator = new JsonAppConfigurationLoaderValidator();
        }

        private JObject Source { get; set; }
        private readonly JsonAppConfigurationLoaderValidator _Validator;

        public IAppDirectoryCollection GetDirectories()
        {
            _Validator.ValidateSource(Source);
            var array = Source.GetArray(PROPERTY_DIRECTORIES);

            if (array != null && array.Any())
            {
                return JsonAppDirectoryCollectionConverter.Convert(array);
            }
            else
            {
                return AppDirectoryCollection.Empty;
            }
        }

        public IAppFileCollection GetFiles()
        {
            _Validator.ValidateSource(Source);
            var array = Source.GetArray(PROPERTY_FILES);

            if (array != null && array.Any())
            {
                return JsonAppFileCollectionConverter.Convert(array);
            }
            else
            {
                return AppFileCollection.Empty;
            }
        }

        public IAppSettingCollection GetSettings()
        {
            _Validator.ValidateSource(Source);
            var array = Source.GetArray(PROPERTY_SETTINGS);

            if (array != null && array.Any())
            {
                return JsonAppSettingCollectionConverter.Convert(array);
            }
            else
            {
                return AppSettingCollection.Empty;
            }
        }

        public void Initialize(string configurationFilePath)
        {
            _Validator.ValidateConfigurationFilePath(configurationFilePath);

            try
            {
                Source = JObject.Parse(File.ReadAllText(configurationFilePath));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
