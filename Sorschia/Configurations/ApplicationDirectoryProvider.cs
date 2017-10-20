using Sorschia.Utilities;
using System.Collections.Generic;

namespace Sorschia.Configurations
{
    public sealed class ApplicationDirectoryProvider
    {
        internal ApplicationDirectoryProvider(SorschiaApp sorschiaApp)
        {
            _SorschiaApp = sorschiaApp;
            _Directories = new Dictionary<string, string>();
        }

        private readonly Dictionary<string, string> _Directories;
        private readonly SorschiaApp _SorschiaApp;

        public bool AutoResolveRelativePath { get; set; }
        public bool AutoResolveExistence { get; set; }

        public string this[string key]
        {
            get
            {
                ValidateKey(key);
                if (!_Directories.ContainsKey(key))
                {
                    throw new SorschiaException(nameof(key), SorschiaExceptionKind.KeyNotFound);
                }
                else
                {
                    var directory = TryResolveRelativePath(_Directories[key]);
                    TryResolveExistence(directory);

                    return directory;
                }
            }
            set
            {
                ValidateKey(key);
                if (_Directories.ContainsKey(key))
                {
                    _Directories[key] = value;
                }
                else
                {
                    _Directories.Add(key, value);
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

        private string TryResolveRelativePath(string directory)
        {
            if (AutoResolveRelativePath)
            {
                return _SorschiaApp.ResolveRelativePath(directory);
            }
            else
            {
                return directory;
            }
        }

        private void TryResolveExistence(string directory)
        {
            if (AutoResolveExistence)
            {
                DirectoryResolver.ResolveExistence(directory);
            }
        }
    }
}
