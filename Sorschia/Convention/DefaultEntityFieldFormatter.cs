namespace Sorschia.Convention
{
    public sealed class DefaultEntityFieldFormatter : IEntityFieldFormatter
    {
        public string Format(string field)
        {
            return field;
        }
    }
}
