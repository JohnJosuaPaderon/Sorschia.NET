using System;

namespace Sorschia.Application
{
    public static class AppDirectoryTypeParser
    {
        public static AppDirectoryType Parse(string value)
        {
            AppDirectoryType result;
            Enum.TryParse(value, out result);
            return result;
        }
    }
}
