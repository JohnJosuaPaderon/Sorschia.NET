namespace Sorschia.Application
{
    public interface ISorschiaAppBuilder
    {
        ISorschiaAppSettingLoader SettingLoader { get; set; }
        ISorschiaApp Build();
    }
}
