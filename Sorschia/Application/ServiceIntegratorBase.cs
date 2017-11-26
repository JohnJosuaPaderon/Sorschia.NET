namespace Sorschia.Application
{
    public abstract class ServiceIntegratorBase
    {
        public ServiceIntegratorBase()
        {
            Key = $"asmkey:{GetType().Assembly.FullName}";
        }

        public string Key { get; }
    }
}
