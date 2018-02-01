using System.IO;

namespace Sorschia.Configuration
{
    public abstract class SaveConnectionStringToFileBase
    {
        protected void Validate(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw SorschiaException.ValidationFailed("Invalid path of connection string.");
            }
        }

        protected void UnsafeSaveContent(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}
