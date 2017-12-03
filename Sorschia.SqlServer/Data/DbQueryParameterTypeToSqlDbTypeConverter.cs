using System.Data;

namespace Sorschia.Data
{
    public static class DbQueryParameterTypeToSqlDbTypeConverter
    {
        public static SqlDbType Convert(DbQueryParameterType value)
        {
            switch (value)
            {
                case DbQueryParameterType.NotSet:
                    return SqlDbType.VarChar;
                case DbQueryParameterType.BigInt:
                    return SqlDbType.BigInt;
                case DbQueryParameterType.Binary:
                    return SqlDbType.Binary;
                case DbQueryParameterType.Bit:
                    return SqlDbType.Bit;
                case DbQueryParameterType.Byte:
                    return SqlDbType.Bit;
                case DbQueryParameterType.Char:
                    return SqlDbType.Char;
                case DbQueryParameterType.Boolean:
                    return SqlDbType.Bit;
                case DbQueryParameterType.Currency:
                    return SqlDbType.Money;
                case DbQueryParameterType.Date:
                    return SqlDbType.Date;
                case DbQueryParameterType.DateTime:
                    return SqlDbType.DateTime;
                case DbQueryParameterType.Decimal:
                    return SqlDbType.Decimal;
                case DbQueryParameterType.Float:
                    return SqlDbType.Float;
                case DbQueryParameterType.Int:
                    return SqlDbType.Int;
                case DbQueryParameterType.Money:
                    return SqlDbType.Money;
                case DbQueryParameterType.NChar:
                    return SqlDbType.NChar;
                case DbQueryParameterType.NText:
                    return SqlDbType.NText;
                case DbQueryParameterType.NVarChar:
                    return SqlDbType.NVarChar;
                case DbQueryParameterType.SmallInt:
                    return SqlDbType.SmallInt;
                case DbQueryParameterType.Text:
                    return SqlDbType.Text;
                case DbQueryParameterType.VarBinary:
                    return SqlDbType.VarBinary;
                case DbQueryParameterType.VarChar:
                    return SqlDbType.VarChar;
                case DbQueryParameterType.Double:
                    return SqlDbType.Real;
                case DbQueryParameterType.Guid:
                    return SqlDbType.VarChar;
                case DbQueryParameterType.Int16:
                    return SqlDbType.SmallInt;
                case DbQueryParameterType.Int32:
                    return SqlDbType.Int;
                case DbQueryParameterType.Int64:
                    return SqlDbType.BigInt;
                case DbQueryParameterType.Object:
                    return SqlDbType.VarChar;
                case DbQueryParameterType.SByte:
                    return SqlDbType.Binary;
                case DbQueryParameterType.Single:
                    return SqlDbType.Float;
                case DbQueryParameterType.String:
                    return SqlDbType.VarChar;
                case DbQueryParameterType.Time:
                    return SqlDbType.Time;
                case DbQueryParameterType.UInt16:
                    return SqlDbType.SmallInt;
                case DbQueryParameterType.UInt32:
                    return SqlDbType.Int;
                case DbQueryParameterType.UInt64:
                    return SqlDbType.BigInt;
                default:
                    return SqlDbType.VarChar;
            }
        }
    }
}
