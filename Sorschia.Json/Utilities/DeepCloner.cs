using Newtonsoft.Json;

namespace Sorschia.Utilities
{
    public static class DeepCloner
    {
        public static T Clone<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
