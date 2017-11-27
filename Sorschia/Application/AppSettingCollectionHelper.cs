namespace Sorschia.Application
{
    internal sealed class AppSettingCollectionHelper
    {
        static AppSettingCollectionHelper()
        {
            Instance = new AppSettingCollectionHelper();
        }

        public static AppSettingCollectionHelper Instance { get; }

        public void ValidateSetting(IAppSetting setting)
        {
            if (setting == null)
            {
                throw SorschiaException.ParameterRequired(nameof(setting));
            }
        }

        public SorschiaException ComposeParameterRequiredError(string parameterName)
        {
            return SorschiaException.ParameterRequired(parameterName);
        }

        public SorschiaException ComposeItemDuplicationError(string key)
        {
            return SorschiaException.CollectionItemDuplication($"Setting with key '{key}' is already exists in the collection.");
        }

        public SorschiaException ComposeItemNotExistsError(string key)
        {
            return SorschiaException.CollectionItemNotExists($"Setting with key '{key}' doesn't exists in the collection.");
        }
    }
}
