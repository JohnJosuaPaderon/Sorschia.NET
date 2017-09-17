using System.Data;

namespace Sorschia.Data
{
    public static class QueryTypeConverter
    {
        public static CommandType ToCommandType(QueryType queryType)
        {
            switch (queryType)
            {
                case QueryType.DirectQuery: return CommandType.Text;
                case QueryType.ProcedureCall: return CommandType.StoredProcedure;
                case QueryType.FunctionCall: return CommandType.StoredProcedure;
                default: return CommandType.Text;
            }
        }
    }
}
