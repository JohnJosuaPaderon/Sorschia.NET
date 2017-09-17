using Sorschia.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace Sorschia.Extensions
{
    public static class DbDataReaderExtension
    {
        private static void ValidateGetterArguments(DbDataReader reader, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new SorschiaException(nameof(fieldName), SorschiaExceptionType.ValueRequired);
            }

            if (reader.FieldCount <= 0)
            {
                throw new SorschiaException(nameof(reader), SorschiaExceptionType.EmptyCollection);
            }
        }

        private static TResult GetValueBase<TResult>(DbDataReader reader, string fieldName, Func<object, TResult> converter)
        {
            ValidateGetterArguments(reader, fieldName);
            return converter(reader[fieldName]);
        }

        private static TResult GetValueBase<TResult>(DbDataReader reader, string fieldName, IFormatProvider formatProvider, Func<object, IFormatProvider, TResult> converter)
        {
            ValidateGetterArguments(reader, fieldName);
            return converter(reader[fieldName], formatProvider);
        }

        public static bool GetBoolean(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToBoolean);
        }

        public static bool GetBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToBoolean);
        }

        public static byte GetByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToByte);
        }

        public static byte GetByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToByte);
        }

        public static char GetChar(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToChar);
        }

        public static char GetChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToDateTime);
        }

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToDecimal);
        }

        public static decimal GetDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToDecimal);
        }

        public static double GetDouble(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToDouble);
        }

        public static double GetDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToDouble);
        }

        public static short GetInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToInt16);
        }

        public static short GetInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToInt16);
        }

        public static int GetInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToInt32);
        }

        public static int GetInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToInt32);
        }

        public static long GetInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToInt64);
        }

        public static long GetInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableBoolean);
        }

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableByte);
        }

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableChar);
        }

        public static char? GetNullableChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableDateTime);
        }

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableDecimal);
        }

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableDouble);
        }

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableInt16);
        }

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableInt32);
        }

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableInt32);
        }

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableInt64);
        }

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableSByte);
        }

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableSingle);
        }

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableSingle);
        }

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableUInt16);
        }

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableUInt32);
        }

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableUInt64);
        }

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToSByte);
        }

        public static sbyte GetSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToSByte);
        }

        public static float GetSingle(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToSingle);
        }

        public static float GetSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToSingle);
        }

        public static string GetString(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToString);
        }

        public static string GetString(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToString);
        }

        public static ushort GetUInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToUInt16);
        }

        public static ushort GetUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToUInt32);
        }

        public static uint GetUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToUInt64);
        }

        public static ulong GetUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(instance, fieldName, formatProvider, DbValueConverter.ToUInt64);
        }

        public static byte[] GetByteArray(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToByteArray);
        }

        public static Stream GetStream(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToStream);
        }

        public static TimeSpan GetTimeSpan(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToTimeSpan);
        }

        public static TimeSpan? GetNullableTimeSpan(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableTimeSpan);
        }

        public static Dictionary<string, object> ToDictionary(this DbDataReader instance)
        {
            var dictionary = new Dictionary<string, object>();
            for (int i = 0; i < instance.FieldCount; i++)
            {
                dictionary.Add(instance.GetName(i), instance.GetValue(i));
            }
            return dictionary;
        }
    }
}
