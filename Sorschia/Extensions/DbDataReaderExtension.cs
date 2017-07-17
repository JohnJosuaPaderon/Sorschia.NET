using Sorschia.Utilities;
using System;
using System.Data.Common;
using System.IO;

namespace Sorschia.Extensions
{
    public static class DbDataReaderExtension
    {
        private static void Validate(DbDataReader reader, string fieldName)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            if (reader.FieldCount <= 0)
            {
                throw new ArgumentException(nameof(reader), "Data reader has no fields.");
            }

            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentException(nameof(fieldName), "Field name is invalid.");
            }
        }

        private static T GetValueBase<T>(DbDataReader reader, string fieldName, Func<object, T> converter)
        {
            Validate(reader, fieldName);
            return converter(reader[fieldName]);
        }

        public static bool GetBoolean(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToBoolean);
        }

        public static byte GetByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToByte);
        }

        public static char GetChar(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToDecimal);
        }

        public static double GetDouble(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToDouble);
        }

        public static short GetInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToInt16);
        }

        public static int GetInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToInt32);
        }

        public static long GetInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableInt16);
        }

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableSingle);
        }

        public static TimeSpan? GetNullableTimeSpan(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableTimeSpan);
        }

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToSByte);
        }

        public static float GetSingle(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToSingle);
        }

        public static Stream GetStream(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToStream);
        }

        public static string GetString(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToString);
        }

        public static TimeSpan GetTimeSpan(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToTimeSpan);
        }

        public static ushort GetUInt16(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this DbDataReader instance, string fieldName)
        {
            return GetValueBase(instance, fieldName, DbValueConverter.ToUInt64);
        }
    }
}
