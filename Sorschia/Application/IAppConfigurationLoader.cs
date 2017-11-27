namespace Sorschia.Application
{
    public interface IAppConfigurationLoader
    {
        void Initialize(string configurationFilePath);
        IAppDirectoryCollection GetDirectories();
        IAppFileCollection GetFiles();
        IAppSettingCollection GetSettings();
    }
}
