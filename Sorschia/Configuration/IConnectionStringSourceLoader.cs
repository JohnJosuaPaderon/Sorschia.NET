namespace Sorschia.Configuration
{
    public interface IConnectionStringSourceLoader
    {
        void Load(IConnectionStringSource connectionStringSource);
    }
}
