namespace Sorschia.Security
{
    public abstract class CryptoServiceBase : ICryptoService
    {
        public CryptoServiceBase(ICryptoKeyProvider keyProvider, IEncryptor encryptor, IDecryptor decryptor, string cryptoKeyName)
        {
            if (string.IsNullOrWhiteSpace(_CryptoKeyName))
            {
                throw SorschiaException.ParameterRequired(nameof(_CryptoKeyName));
            }

            _CryptoKeyName = cryptoKeyName;
            _KeyProvider = keyProvider;
            _Encryptor = encryptor;
            _Decryptor = decryptor;
        }

        private readonly string _CryptoKeyName;
        private readonly ICryptoKeyProvider _KeyProvider;
        private readonly IEncryptor _Encryptor;
        private readonly IDecryptor _Decryptor;

        public string Encrypt(string value)
        {
            return Encrypt(value, false);
        }

        public string Encrypt(string value, bool isCompressed)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw SorschiaException.ParameterRequired(nameof(value), "Cannot encrypt null or whitespace string.");
            }

            return _Encryptor.Encrypt(value, _KeyProvider[_CryptoKeyName], isCompressed);
        }

        public string Decrypt(string value)
        {
            return Decrypt(value, false);
        }

        public string Decrypt(string value, bool isCompressed)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw SorschiaException.ParameterRequired(nameof(value), "Cannot decrypt null or whitespace string.");
            }

            return _Decryptor.Decrypt(value, _KeyProvider[_CryptoKeyName], isCompressed);
        }
    }
}
