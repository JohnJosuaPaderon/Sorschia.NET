namespace Sorschia.Convention
{
    public sealed class DefaultEntityParameterFormatter : IEntityParameterFormatter
    {
        public string Format(string parameter)
        {
            return $"@_{parameter}";
        }
    }
}
