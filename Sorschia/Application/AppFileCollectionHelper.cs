namespace Sorschia.Application
{
    internal sealed class AppFileCollectionHelper
    {
        static AppFileCollectionHelper()
        {
            Instance = new AppFileCollectionHelper();
        }

        public static AppFileCollectionHelper Instance { get; }

        public void ValidateFile(IAppFile file)
        {
            if (file == null)
            {
                throw SorschiaException.ParameterRequired(nameof(file));
            }
        }

        public SorschiaException ComposeItemDuplicationError(string key)
        {
            return SorschiaException.CollectionItemDuplication($"File with key '{key}' is already exists in the collection.");
        }

        public SorschiaException ComposeItemNotExistsError(string key)
        {
            return SorschiaException.CollectionItemNotExists($"File with key '{key}' doesn't exists in the collection.");
        }
    }
}
