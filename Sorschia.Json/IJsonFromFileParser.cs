using Newtonsoft.Json.Linq;

namespace Sorschia
{
    public interface IJsonFromFileParser
    {
        JObject ParseObject(string filePath);
        JArray ParseArray(string filePath);
    }
}
