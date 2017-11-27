namespace Sorschia.Application
{
    internal sealed class AppDirectoryCollectionHelper
    {
        static AppDirectoryCollectionHelper()
        {
            Instance = new AppDirectoryCollectionHelper();
        }

        public static AppDirectoryCollectionHelper Instance { get; }

        public void ValidateDirectory(IAppDirectory directory)
        {
            if (directory == null)
            {
                throw SorschiaException.ParameterRequired(nameof(directory));
            }
        }

        public SorschiaException ComposeItemDuplicationError(string key)
        {
            return SorschiaException.CollectionItemDuplication($"Directory with key '{key}' is already exists in the collection.");
        }

        public SorschiaException ComposeItemNotExistsError(string key)
        {
            return SorschiaException.CollectionItemNotExists($"Directory with key '{key}' doesn't exists in the collection.");
        }
    }
}
