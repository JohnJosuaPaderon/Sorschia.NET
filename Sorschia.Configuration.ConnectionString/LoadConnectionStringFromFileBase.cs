using System.IO;

namespace Sorschia.Configuration
{
    public abstract class LoadConnectionStringFromFileBase
    {
        protected void Validate(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw SorschiaException.ValidationFailed("Invalid path of connection string.");
            }
            else if (!File.Exists(filePath))
            {
                throw SorschiaException.FileNotFound(filePath);
            }
        }

        protected string UnsafeLoadContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
