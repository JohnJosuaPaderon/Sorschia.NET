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

        public SorschiaException ComposeItemDuplicationError(AppFileType type)
        {
            return SorschiaException.CollectionItemDuplication($"File of type '{type}' is already exists in the collection.");
        }

        public SorschiaException ComposeItemNotExistsError(AppFileType type)
        {
            return SorschiaException.CollectionItemNotExists($"File of type '{type}' doesn't exists in the collection.");
        }
    }
}
