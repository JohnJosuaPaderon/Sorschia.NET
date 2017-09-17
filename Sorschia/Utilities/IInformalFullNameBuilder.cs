namespace Sorschia.Utilities
{
    public interface IInformalFullNameBuilder
    {
        string Build(string firstName, string middleInitials, string lastName, string nameExtension);
    }
}
