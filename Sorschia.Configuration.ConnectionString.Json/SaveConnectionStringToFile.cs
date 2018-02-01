using Newtonsoft.Json.Linq;

namespace Sorschia.Configuration
{
    internal sealed partial class SaveConnectionStringToFile : SaveConnectionStringToFileBase, ISaveConnectionStringToFile
    {
        public void Save(string filePath, IConnectionStringCollection connectionStrings)
        {
            Validate(filePath);

            var jArray = new JArray();

            foreach (var connectionString in connectionStrings)
            {
                jArray.Add(ConnectionStringConverter.Convert(connectionString));
            }

            UnsafeSaveContent(filePath, jArray.ToString());
        }
    }
}
