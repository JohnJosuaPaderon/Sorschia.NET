using Sorschia.Utilities;
using System;
using System.Data.Common;
using System.IO;

namespace Sorschia.Extensions
{
    public static class DbParameterCollectionExtension
    {
        private static void ValidateGetterArguments(DbParameterCollection parameters, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new SorschiaException(nameof(parameterName), SorschiaExceptionType.ValueRequired);
            }

            if (parameters.Count <= 0)
            {
                throw new SorschiaException(nameof(parameterName), SorschiaExceptionType.EmptyCollection);
            }
        }

        private static TResult GetValueBase<TResult>(DbParameterCollection parameters, string parameterName, Func<object, TResult> converter)
        {
            ValidateGetterArguments(parameters, parameterName);
            return converter(parameters[parameterName].Value);
        }

        private static TResult GetValueBase<TResult>(DbParameterCollection parameters, string parameterName, IFormatProvider formatProvider, Func<object, IFormatProvider, TResult> converter)
        {
            ValidateGetterArguments(parameters, parameterName);
            return converter(parameters[parameterName].Value, formatProvider);
        }

        public static bool GetBoolean(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToBoolean);
        }

        public static bool GetBoolean(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToBoolean);
        }

        public static byte GetByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToByte);
        }

        public static byte GetByte(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToByte);
        }

        public static char GetChar(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToChar);
        }

        public static char GetChar(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToDateTime);
        }

        public static DateTime GetDateTime(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToDecimal);
        }

        public static decimal GetDecimal(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToDecimal);
        }

        public static double GetDouble(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToDouble);
        }

        public static double GetDouble(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToDouble);
        }

        public static short GetInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToInt16);
        }

        public static short GetInt16(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToInt16);
        }

        public static int GetInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToInt32);
        }

        public static int GetInt32(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToInt32);
        }

        public static long GetInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToInt64);
        }

        public static long GetInt64(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableBoolean);
        }

        public static bool? GetNullableBoolean(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableByte);
        }

        public static byte? GetNullableByte(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableChar);
        }

        public static char? GetNullableChar(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableDateTime);
        }

        public static DateTime? GetNullableDateTime(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableDecimal);
        }

        public static decimal? GetNullableDecimal(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableDouble);
        }

        public static double? GetNullableDouble(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableInt16);
        }

        public static short? GetNullableInt16(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableInt32);
        }

        public static int? GetNullableInt32(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableInt32);
        }

        public static long? GetNullableInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableInt64);
        }

        public static long? GetNullableInt64(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableSByte);
        }

        public static sbyte? GetNullableSByte(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableSingle);
        }

        public static float? GetNullableSingle(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableSingle);
        }

        public static ushort? GetNullableUInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableUInt16);
        }

        public static ushort? GetNullableUInt16(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableUInt32);
        }

        public static uint? GetNullableUInt32(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableUInt64);
        }

        public static ulong? GetNullableUInt64(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToSByte);
        }

        public static sbyte GetSByte(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToSByte);
        }

        public static float GetSingle(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToSingle);
        }

        public static float GetSingle(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToSingle);
        }

        public static string GetString(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToString);
        }

        public static string GetString(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToString);
        }

        public static ushort GetUInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToUInt16);
        }

        public static ushort GetUInt16(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToUInt32);
        }

        public static uint GetUInt32(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToUInt64);
        }

        public static ulong GetUInt64(this DbParameterCollection instance, string parameterName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, parameterName, formatProvider, DbValueConverter.ToUInt64);
        }

        public static Stream GetStream(this DbParameterCollection instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToStream);
        }

        public static TimeSpan GetTimeSpan(this DbParameterCollection instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToTimeSpan);
        }

        public static TimeSpan? GetNullableTimeSpan(this DbParameterCollection instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableTimeSpan);
        }
    }
}
