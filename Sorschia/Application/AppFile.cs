namespace Sorschia.Application
{
    public sealed class AppFile : IAppFile
    {
        public AppFile(AppFileType type)
        {
            Type = type;
        }

        public AppFileType Type { get; }
        public string Path { get; set; }
        public bool IsRequired { get; set; }
    }
}
