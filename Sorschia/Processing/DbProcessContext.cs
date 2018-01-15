using Sorschia.Application;

namespace Sorschia.Processing
{
    public sealed class DbProcessContext : ProcessContextBase, IProcessContext
    {
        public string ConnectionStringKey { get; set; }

        public void Dispose()
        {
            var factory = SorschiaApp.GetService<IProcessContextFactory>();
            factory.Finish(this);
        }
    }
}
