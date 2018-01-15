using System.IO;

namespace Sorschia.Configuration
{
    public abstract class ConnectionStringFromFileLoaderBase
    {
        public ConnectionStringFromFileLoaderBase(IConnectionStringFileSource source)
        {
            _Source = source;
        }

        protected readonly IConnectionStringFileSource _Source;

        protected void ValidateSource()
        {
            if (_Source == null)
            {
                throw SorschiaException.FieldRequired("ConnectionStringFileSource");
            }
            else if (!File.Exists(_Source.FilePath))
            {
                throw SorschiaException.FileNotFound(_Source.FilePath);
            }
        }
    }
}
