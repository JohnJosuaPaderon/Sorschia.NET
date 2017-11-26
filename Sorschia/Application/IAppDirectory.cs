namespace Sorschia.Application
{
    public interface IAppDirectory
    {
        AppDirectoryType Type { get; }
        string Path { get; set; }
        bool IsRequired { get; set; }
    }
}
