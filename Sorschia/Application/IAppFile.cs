namespace Sorschia.Application
{
    public interface IAppFile
    {
        AppFileType Type { get; }
        string Path { get; set; }
        bool IsRequired { get; set; }
    }
}
