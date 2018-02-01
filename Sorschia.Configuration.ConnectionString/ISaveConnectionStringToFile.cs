namespace Sorschia.Configuration
{
    public interface ISaveConnectionStringToFile
    {
        void Save(string filePath, IConnectionStringCollection connectionStrings);
    }
}
