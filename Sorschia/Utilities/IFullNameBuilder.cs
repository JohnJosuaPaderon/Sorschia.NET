namespace Sorschia.Utilities
{
    public interface IFullNameBuilder
    {
        string Build(string lastName, string firstName, string nameExtension, string middleName);
    }
}
