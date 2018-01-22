using Sorschia.Processing;

namespace Sorschia.Data
{
    partial class DbConnectionProviderBase<TConnection>
    {
        public TConnection Request(IProcessContext processContext)
        {
            return _Source[processContext];
        }
    }
}
