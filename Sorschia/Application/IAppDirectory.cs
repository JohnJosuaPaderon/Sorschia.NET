namespace Sorschia.Application
{
    public interface IAppDirectory
    {
        string Key { get; set; }
        string Path { get; set; }
        bool IsRequired { get; set; }
    }
}
