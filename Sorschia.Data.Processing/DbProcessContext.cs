using Sorschia.Processing;
using System;

namespace Sorschia.Data.Processing
{
    public sealed class DbProcessContext : ProcessContextBase, IProcessContext
    {
        public string ConnectionStringKey { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
            //var factory = SorschiaApp.GetService<IProcessContextFactory>();
            //factory.Finish(this);
        }
    }
}
