using Sorschia.Application;
using System.IO;

namespace Sorschia.Utilities
{
    public static class DirectoryResolver
    {
        public static void ResolveExistence(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw SorschiaException.ParameterRequired(nameof(directory));
            }
            else if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static string Resolve(ISorschiaApp app, string directory)
        {
            foreach (var appDirectory in app.Directories)
            {
                var placeholder = $"<{appDirectory.Key}>";
                if (directory.Contains(placeholder))
                {
                    directory = directory.Replace(placeholder, appDirectory.Path);
                }
            }

            return directory;
        }
    }
}
