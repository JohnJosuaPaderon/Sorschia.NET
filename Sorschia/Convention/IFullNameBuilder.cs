namespace Sorschia.Convention
{
    public interface IFullNameBuilder
    {
        string Build(string lastName, string firstName, string nameExtension, string middleName);
    }
}
