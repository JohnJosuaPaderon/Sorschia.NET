namespace Sorschia.Configuration
{
    public sealed class ConnectionStringFileSource : IConnectionStringFileSource
    {
        public ConnectionStringFileSource(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
