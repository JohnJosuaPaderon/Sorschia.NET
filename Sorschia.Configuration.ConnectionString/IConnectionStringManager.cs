namespace Sorschia.Configuration
{
    public interface IConnectionStringManager
    {
        IConnectionStringCollection LoadFromFile(string filePath);
        void SaveToFile(string filePath, IConnectionStringCollection connectionStrings);
    }
}
