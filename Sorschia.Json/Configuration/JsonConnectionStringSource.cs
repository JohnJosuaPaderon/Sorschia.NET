namespace Sorschia.Configuration
{
    public sealed class JsonConnectionStringSource : ConnectionStringSourceBase, IConnectionStringSource
    {
        public JsonConnectionStringSource(IConnectionStringSourceLoader loader) : base(loader)
        {
        }
    }
}
