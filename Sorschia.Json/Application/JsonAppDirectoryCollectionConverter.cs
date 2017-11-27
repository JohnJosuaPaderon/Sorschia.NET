using Newtonsoft.Json.Linq;
using System.Linq;

namespace Sorschia.Application
{
    public static class JsonAppDirectoryCollectionConverter
    {
        public static JArray Convert(IAppDirectoryCollection directories)
        {
            if (directories == null)
            {
                throw SorschiaException.ParameterRequired(nameof(directories));
            }
            else if (!directories.Any())
            {
                throw SorschiaException.EmptyCollection(nameof(directories));
            }

            var result = new JArray();

            foreach (var directory in directories)
            {
                result.Add(JsonAppDirectoryConverter.Convert(directory));
            }

            return result;
        }

        public static IAppDirectoryCollection Convert(JArray jDirectories)
        {
            if (jDirectories == null)
            {
                throw SorschiaException.ParameterRequired(nameof(jDirectories));
            }
            else if (!jDirectories.Any())
            {
                throw SorschiaException.EmptyCollection(nameof(jDirectories));
            }

            var result = new AppDirectoryCollection();

            foreach (JObject jDirectory in jDirectories)
            {
                result.Add(JsonAppDirectoryConverter.Convert(jDirectory));
            }

            return result;
        }
    }
}
