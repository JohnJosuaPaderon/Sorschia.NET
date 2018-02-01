namespace Sorschia.Configuration
{
    public interface ILoadConnectionStringFromFile
    {
        IConnectionStringCollection Load(string filePath);
    }
}
