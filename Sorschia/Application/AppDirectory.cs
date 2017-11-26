namespace Sorschia.Application
{
    public sealed class AppDirectory : IAppDirectory
    {
        public AppDirectory(AppDirectoryType type)
        {
            Type = type;
        }

        public AppDirectoryType Type { get; }
        public string Path { get; set; }
        public bool IsRequired { get; set; }
    }
}
