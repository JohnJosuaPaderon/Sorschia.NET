namespace Sorschia.Application
{
    public interface ISorschiaApp
    {
        ISorschiaAppSettingCollection Settings { get; }
        SorschiaAppEnvironment Environment { get; }
        string CurrentDirectory { get; }
        void Run();
        void Stop();
    }
}
