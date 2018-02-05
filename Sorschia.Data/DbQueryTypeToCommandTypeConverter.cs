using System.Data;

namespace Sorschia.Data
{
    public static class DbQueryTypeToCommandTypeConverter
    {
        public static CommandType Convert(DbQueryType type)
        {
            switch (type)
            {
                case DbQueryType.StoredProcedure:
                    return CommandType.StoredProcedure;
                case DbQueryType.Text:
                    return CommandType.Text;
                default:
                    throw SorschiaException.InvalidOperation($"{typeof(DbQueryType).FullName}.{type} is not supported.");
            }
        }

        public static DbQueryType Convert(CommandType type)
        {
            switch (type)
            {
                case CommandType.StoredProcedure:
                    return DbQueryType.StoredProcedure;
                case CommandType.Text:
                    return DbQueryType.Text;
                default:
                    throw SorschiaException.InvalidOperation($"{typeof(CommandType).FullName}.{type} is not supported.");
            }
        }
    }
}
