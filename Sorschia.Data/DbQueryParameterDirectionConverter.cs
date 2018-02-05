using System.Data;

namespace Sorschia.Data
{
    public static class DbQueryParameterDirectionConverter
    {
        public static ParameterDirection Convert(DbQueryParameterDirection value)
        {
            switch (value)
            {
                case DbQueryParameterDirection.In:
                    return ParameterDirection.Input;
                case DbQueryParameterDirection.Out:
                    return ParameterDirection.Output;
                case DbQueryParameterDirection.InOut:
                    return ParameterDirection.InputOutput;
                default:
                    return ParameterDirection.Input;
            }
        }
    }
}
