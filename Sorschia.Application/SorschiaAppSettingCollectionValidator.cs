namespace Sorschia.Application
{
    internal sealed class SorschiaAppSettingCollectionValidator
    {
        static SorschiaAppSettingCollectionValidator()
        {
            Instance = new SorschiaAppSettingCollectionValidator();
        }

        public static SorschiaAppSettingCollectionValidator Instance { get; }

        public void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw SorschiaAppException.InvalidSettingName();
            }
        }
    }
}
