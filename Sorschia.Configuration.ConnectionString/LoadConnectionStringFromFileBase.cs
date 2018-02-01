using System.IO;

namespace Sorschia.Configuration
{
    public abstract class LoadConnectionStringFromFileBase
    {
        protected void Validate(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw SorschiaException.FieldRequired(nameof(filePath));
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
