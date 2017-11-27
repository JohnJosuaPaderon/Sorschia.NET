namespace Sorschia.Application
{
    public interface IAppFile
    {
        string Key { get; set; }
        string Path { get; set; }
        bool IsRequired { get; set; }
    }
}
