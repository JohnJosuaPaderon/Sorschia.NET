using System.IO;

namespace Sorschia.Utilities
{
    public static class DirectoryResolver
    {
        public static void ResolveExistence(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw new SorschiaException(SorschiaExceptionKind.ValueRequired);
            }
            else if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
