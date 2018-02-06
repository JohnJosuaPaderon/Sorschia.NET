using Sorschia.Processing;
using System.Security;

namespace Sorschia.Data.Processing
{
    public sealed class DbProcessContext : ProcessContextBase, IProcessContext
    {
        public SecureString SecureConnectionString { get; set; }

        public void Dispose()
        {
            SecureConnectionString.Dispose();
            var factory = SorschiaServiceResolver.Resolve<IProcessContextFactory>();
            factory.Finish(this);
        }
    }
}
