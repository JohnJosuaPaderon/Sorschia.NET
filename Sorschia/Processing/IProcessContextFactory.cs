namespace Sorschia.Processing
{
    public interface IProcessContextFactory
    {
        IProcessContext Generate();
        void Finish(IProcessContext context);
    }
}
