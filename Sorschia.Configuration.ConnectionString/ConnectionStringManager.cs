namespace Sorschia.Configuration
{
    internal sealed class ConnectionStringManager : IConnectionStringManager
    {
        public ConnectionStringManager(ILoadConnectionStringFromFile loadFromFile, ISaveConnectionStringToFile saveToFile)
        {
            _LoadFromFile = loadFromFile;
            _SaveToFile = saveToFile;
        }

        private readonly ILoadConnectionStringFromFile _LoadFromFile;
        private readonly ISaveConnectionStringToFile _SaveToFile;

        public IConnectionStringCollection LoadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return _LoadFromFile.Load(filePath);
            }
            else
            {
                return null;
            }
        }

        public void SaveToFile(string filePath, IConnectionStringCollection connectionStrings)
        {
            if (string.IsNullOrWhiteSpace(filePath) &&  connectionStrings != null)
            {
                _SaveToFile.Save(filePath, connectionStrings);
            }
        }
    }
}
