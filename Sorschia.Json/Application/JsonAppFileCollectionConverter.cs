using Newtonsoft.Json.Linq;
using System.Linq;

namespace Sorschia.Application
{
    public static class JsonAppFileCollectionConverter
    {
        public static JArray Convert(IAppFileCollection files)
        {
            if (files == null)
            {
                throw SorschiaException.ParameterRequired(nameof(files));
            }
            else if (!files.Any())
            {
                throw SorschiaException.EmptyCollection(nameof(files));
            }

            var result = new JArray();

            foreach (var file in files)
            {
                result.Add(JsonAppFileConverter.Convert(file));
            }

            return result;
        }

        public static IAppFileCollection Convert(JArray jFiles)
        {
            if (jFiles == null)
            {
                throw SorschiaException.ParameterRequired(nameof(jFiles));
            }
            else if (!jFiles.Any())
            {
                throw SorschiaException.EmptyCollection(nameof(jFiles));
            }

            var result = new AppFileCollection();

            foreach (JObject jFile in jFiles)
            {
                result.Add(JsonAppFileConverter.Convert(jFile));
            }

            return result;
        }
    }
}
