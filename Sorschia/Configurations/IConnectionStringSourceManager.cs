using Newtonsoft.Json.Linq;

namespace Sorschia.Configurations
{
    public interface IConnectionStringSourceManager
    {
        ConnectionStringSource Parse(JObject source);
        ConnectionStringSource FromFile(string connectionStringSourcePath);
    }
}
