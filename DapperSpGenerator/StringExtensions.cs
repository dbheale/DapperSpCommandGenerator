using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSpGenerator
{
    internal static class StringExtensions
    {
        public static bool HasContent(this string? val)
        {
            return !string.IsNullOrEmpty(val?.Trim());
        }

        public static string ToUpperFirstCharacter(this string value)
        {
            return char.ToUpper(value[0]) + value[1..];
        }

        public static string GetSqlType(this string? typeName)
        {
            return typeName switch
            {
                "image" => "SqlDbType.Image",
                "text" => "SqlDbType.Text",
                "uniqueidentifier" => "SqlDbType.UniqueIdentifier",
                "date" => "SqlDbType.Date",
                "time" => "SqlDbType.Time",
                "datetime2" => "SqlDbType.DateTime2",
                "datetimeoffset" => "SqlDbType.DateTimeOffset",
                "tinyint" => "SqlDbType.TinyInt",
                "smallint" => "SqlDbType.SmallInt",
                "int" => "SqlDbType.Int",
                "smalldatetime" => "SqlDbType.SmallDateTime",
                "real" => "SqlDbType.Real",
                "money" => "SqlDbType.Money",
                "datetime" => "SqlDbType.DateTime",
                "float" => "SqlDbType.Float",
                "sql_variant" => "SqlDbType.Variant",
                "ntext" => "SqlDbType.NText",
                "bit" => "SqlDbType.Bit",
                "decimal" => "SqlDbType.Decimal",
                "smallmoney" => "SqlDbType.SmallMoney",
                "bigint" => "SqlDbType.BigInt",
                "varbinary" => "SqlDbType.VarBinary",
                "varchar" => "SqlDbType.VarChar",
                "binary" => "SqlDbType.Binary",
                "char" => "SqlDbType.Char",
                "timestamp" => "SqlDbType.Timestamp",
                "nvarchar" => "SqlDbType.NVarChar",
                "nchar" => "SqlDbType.NChar",
                "xml" => "SqlDbType.Xml",
                _ => "SqlDbType.Udt",
            };
        }

        public static string GetDbType(this string? typeName)
        {
            return typeName switch
            {
                "uniqueidentifier" => "DbType.Guid",
                "date" => "DbType.Date",
                "time" => "DbType.Time",
                "smalldatetime" => "DbType.DateTime",
                "datetime2" => "DbType.DateTime2",
                "datetimeoffset" => "DbType.DateTimeOffset",
                "tinyint" => "DbType.UInt16",
                "smallint" => "DbType.Int16",
                "int" => "DbType.Int32",
                "bigint" => "DbType.Int64",
                "money" or "smallmoney" => "DbType.Currency",
                "datetime" => "DbType.DateTime",
                "float" => "DbType.Double",
                "bit" => "DbType.Boolean",
                "decimal" => "DbType.Decimal",
                "varbinary" => "DbType.Binary",
                "varchar" or "ntext" or "text" or "char" or "nvarchar" or "nchar" => "DbType.String",
                "binary" => "DbType.Binary",
                "xml" => "DbType.Xml",
                _ => "DbType.Object",
            };
        }

        public static string GetCSharpType(this string? typeName)
        {
            return typeName switch
            {
                "date" or "datetime" or "smalldatetime" or "datetime2" => "DateTime?",
                "time" => "TimeSpan?",
                "datetimeoffset" => "DateTimeOffset?",
                "tinyint" => "byte?",
                "smallint" => "short?",
                "int" => "int",
                "bigint" => "long?",
                "real" => "float?>",
                "float" => "double?",
                "bit" => "bool?",
                "decimal" or "numeric" or "money" or "smallmoney" => "decimal?",
                "image" or "binary" or "varbinary" or "timestamp" => "byte[]?",
                "text" or "ntext" or "char" or "nchar" or "varchar" or "nvarchar" => "string?",
                _ => "object?",
            };
        }
    }
}
