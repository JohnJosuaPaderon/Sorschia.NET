namespace Sorschia.Security
{
    public interface ICryptoService
    {
        string Encrypt(string value);
        string Encrypt(string value, bool isCompressed);
        string Decrypt(string value);
        string Decrypt(string value, bool isCompressed);
    }
}
