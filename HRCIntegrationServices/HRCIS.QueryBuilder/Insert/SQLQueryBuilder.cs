using System;
using HRCIS.SchemaLoader.Enums;

namespace HRCIS.QueryBuilder.Insert
{
    public class SqlQueryBuilder : InsertQueryStrategy
    {
        protected override bool HasApostrophe(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Undefiened:
                    return true;
                case DataType.STRING:
                    return true;
                case DataType.DATETIME:
                    return true;
                case DataType.GUID:
                    return true;
                case DataType.Char:
                    return true;
                case DataType.XML:
                    return true;
                default:
                    return false;
            }
        }

        protected override string ConvertToDbBooleanValue(bool value)
        {
            return value ? "1" : "0";
        }
        protected override string ConvertToDbDateTimeValue(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }
        protected override string ConvertToDbStringValue(string value)
        {
            return value.Replace("'", "''");
        }
        protected override string ConvertToDbDecimalValue(decimal value)
        {
            return value.ToString().Replace(",", ".");
        }

        protected override string ConvertToDbFloatValue(float value)
        {
            return value.ToString().Replace(",", ".");
        }
        protected override string ConvertToDbMoneyValue(decimal value)
        {
            return value.ToString().Replace(",", ".");
        }

        protected override string ConvertToDefaultValue(string value)
        {
            return value.Replace("'", "''");
        }

        protected override string ConvertToDbGuidValue(Guid value)
        {
            return value.ToString();
        }

        protected override string GetDataTypeMap(DataType dataType)
        {
            return string.Empty;
        }
    }
}
