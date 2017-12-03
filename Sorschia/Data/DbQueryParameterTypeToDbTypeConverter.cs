using System.Data;

namespace Sorschia.Data
{
    public static class DbQueryParameterTypeToDbTypeConverter
    {
        public static DbType Convert(DbQueryParameterType value)
        {
            switch (value)
            {
                case DbQueryParameterType.NotSet:
                    return DbType.Object;
                case DbQueryParameterType.BigInt:
                    return DbType.Int64;
                case DbQueryParameterType.Binary:
                    return DbType.Binary;
                case DbQueryParameterType.Bit:
                    return DbType.Boolean;
                case DbQueryParameterType.Byte:
                    return DbType.Byte;
                case DbQueryParameterType.Char:
                    return DbType.StringFixedLength;
                case DbQueryParameterType.Boolean:
                    return DbType.Boolean;
                case DbQueryParameterType.Currency:
                    return DbType.Currency;
                case DbQueryParameterType.Date:
                    return DbType.Date;
                case DbQueryParameterType.DateTime:
                    return DbType.DateTime;
                case DbQueryParameterType.Decimal:
                    return DbType.Decimal;
                case DbQueryParameterType.Float:
                    return DbType.Single;
                case DbQueryParameterType.Int:
                    return DbType.Int32;
                case DbQueryParameterType.Money:
                    return DbType.Currency;
                case DbQueryParameterType.NChar:
                    return DbType.StringFixedLength;
                case DbQueryParameterType.NText:
                    return DbType.String;
                case DbQueryParameterType.NVarChar:
                    return DbType.String;
                case DbQueryParameterType.SmallInt:
                    return DbType.Int16;
                case DbQueryParameterType.Text:
                    return DbType.String;
                case DbQueryParameterType.VarBinary:
                    return DbType.Binary;
                case DbQueryParameterType.VarChar:
                    return DbType.String;
                case DbQueryParameterType.Double:
                    return DbType.Double;
                case DbQueryParameterType.Guid:
                    return DbType.Guid;
                case DbQueryParameterType.Int16:
                    return DbType.Int16;
                case DbQueryParameterType.Int32:
                    return DbType.Int32;
                case DbQueryParameterType.Int64:
                    return DbType.Int64;
                case DbQueryParameterType.Object:
                    return DbType.Object;
                case DbQueryParameterType.SByte:
                    return DbType.SByte;
                case DbQueryParameterType.Single:
                    return DbType.Single;
                case DbQueryParameterType.String:
                    return DbType.String;
                case DbQueryParameterType.Time:
                    return DbType.Time;
                case DbQueryParameterType.UInt16:
                    return DbType.UInt16;
                case DbQueryParameterType.UInt32:
                    return DbType.UInt32;
                case DbQueryParameterType.UInt64:
                    return DbType.UInt64;
                default:
                    return DbType.Int32;
            }
        }
    }
}
