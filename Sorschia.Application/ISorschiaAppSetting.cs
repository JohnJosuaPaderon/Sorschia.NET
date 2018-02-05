namespace Sorschia.Application
{
    public interface ISorschiaAppSetting
    {
        string Name { get; }
        object Value { get; set; }
    }
}
