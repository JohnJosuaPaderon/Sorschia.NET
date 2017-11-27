using System;

namespace Sorschia.Application
{
    public static class AppFileTypeParser
    {
        public static AppFileType Parse(string value)
        {
            AppFileType result;
            Enum.TryParse(value, out result);
            return result;
        }
    }
}
