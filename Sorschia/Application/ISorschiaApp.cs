namespace Sorschia.Application
{
    public interface ISorschiaApp
    {
        IAppDirectoryCollection Directories { get; }
        IAppFileCollection Files { get; }
    }
}
