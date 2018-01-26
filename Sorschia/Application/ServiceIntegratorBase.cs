namespace Sorschia.Application
{
    public abstract class ServiceIntegratorBase
    {
        public ServiceIntegratorBase(params string[] tags)
        {
            Key = $"asmkey:{GetType().Assembly.FullName}";
            Tags = tags;
        }

        public string Key { get; }
        public string[] Tags { get; }
    }
}
