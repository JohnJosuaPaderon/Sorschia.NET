using System.IO;

namespace Sorschia.Application
{
    public class IAppConfigurationLoaderValidator
    {
        public void ValidateConfigurationFilePath(string configurationFilePath)
        {
            if (string.IsNullOrWhiteSpace(configurationFilePath))
            {
                throw SorschiaException.ParameterRequired(nameof(configurationFilePath));
            }
            else if (!File.Exists(configurationFilePath))
            {
                throw SorschiaException.FileNotFound(configurationFilePath);
            }
        }
    }
}
