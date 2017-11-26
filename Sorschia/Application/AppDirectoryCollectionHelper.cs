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

        public SorschiaException ComposeItemDuplicationError(AppDirectoryType type)
        {
            return SorschiaException.CollectionItemDuplication($"Directory of type '{type}' is already exists in the collection.");
        }

        public SorschiaException ComposeItemNotExistsError(AppDirectoryType type)
        {
            return SorschiaException.CollectionItemNotExists($"Directory of type '{type}' doesn't exists in the collection.");
        }
    }
}
