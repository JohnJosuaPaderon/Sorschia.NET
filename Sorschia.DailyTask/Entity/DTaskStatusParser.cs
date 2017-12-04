using System;

namespace Sorschia.DailyTask.Entity
{
    public static class DTaskStatusParser
    {
        public static DTaskStatus TryParse(string source)
        {
            Enum.TryParse(source, out DTaskStatus value);
            return value;
        }
    }
}
