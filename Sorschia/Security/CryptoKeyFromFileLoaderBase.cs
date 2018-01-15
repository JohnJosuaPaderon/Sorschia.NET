using System.IO;
using System.Security;

namespace Sorschia.Security
{
    public abstract class CryptoKeyFromFileLoaderBase : CryptoKeyLoaderBase
    {
        public CryptoKeyFromFileLoaderBase(string filePath, SecureString secureCryptoKey) : base(secureCryptoKey)
        {
            _FilePath = filePath;
        }

        private readonly string _FilePath;

        protected string LoadContent()
        {
            ValidateFilePath();

            return File.ReadAllText(_FilePath);
        }

        private void ValidateFilePath()
        {
            if (string.IsNullOrWhiteSpace(_FilePath))
            {
                throw SorschiaException.FieldRequired(nameof(_FilePath));
            }
            else if (!File.Exists(_FilePath))
            {
                throw SorschiaException.FileNotFound("Crypto key file.");
            }
        }
    }
}
