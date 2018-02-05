using System.IO;

namespace Sorschia.Application
{
    internal sealed class SorschiaApp : ISorschiaApp
    {
        public SorschiaApp(string currentDirectory, SorschiaAppEnvironment environment)
        {
            if (string.IsNullOrWhiteSpace(currentDirectory))
            {
                throw SorschiaAppException.FatalError("Current directory cannot be null or white space.");
            }
            else if (!Directory.Exists(currentDirectory))
            {
                throw SorschiaAppException.FatalError("Current directory doesn't exists.");
            }

            CurrentDirectory = currentDirectory;
            Settings = new SorschiaAppSettingCollection(this);
            Environment = environment;
        }

        public ISorschiaAppSettingCollection Settings { get; }
        public SorschiaAppEnvironment Environment { get; }
        public string CurrentDirectory { get; }

        public void Run()
        {

        }

        public void Stop()
        {

        }
    }
}
