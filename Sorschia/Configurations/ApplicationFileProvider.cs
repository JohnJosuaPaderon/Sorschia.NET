using System.Collections.Generic;

namespace Sorschia.Configurations
{
    public sealed class ApplicationFileProvider
    {
        internal ApplicationFileProvider(SorschiaApp sorschiaApp)
        {
            _SorschiaApp = sorschiaApp;
            _Files = new Dictionary<string, string>();
        }

        private readonly SorschiaApp _SorschiaApp;
        private readonly Dictionary<string, string> _Files;

        public string this[string key]
        {
            get
            {
                ValidateKey(key);

                if (_Files.ContainsKey(key))
                {
                    return _SorschiaApp.ResolveRelativePath(_Files[key]);
                }
                else
                {
                    throw new SorschiaException(nameof(key), SorschiaExceptionKind.KeyNotFound);
                }
            }
            set
            {
                ValidateKey(key);

                if (_Files.ContainsKey(key))
                {
                    _Files[key] = value;
                }
                else
                {
                    _Files.Add(key, value);
                }
            }
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new SorschiaException(nameof(key), SorschiaExceptionKind.KeyRequired);
            }
        }
    }
}
