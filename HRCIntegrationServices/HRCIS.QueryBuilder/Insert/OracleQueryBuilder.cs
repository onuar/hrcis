using System;

namespace HRCIS.QueryBuilder
{
    public class OracleQueryBuilder : InsertQueryStrategy
    {
        protected override bool HasApostrophe(SchemaLoader.DataType dataType)
        {
            switch (dataType)
            {
                case SchemaLoader.DataType.Undefiened:
                    return true;
                case SchemaLoader.DataType.STRING:
                    return true;
                case SchemaLoader.DataType.DATETIME:
                    return true;
                case SchemaLoader.DataType.GUID:
                    return true;
                case SchemaLoader.DataType.Char:
                    return true;
                case SchemaLoader.DataType.XML:
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
            return value.ToShortDateString();
        }
        protected override string ConvertToDbStringValue(string value)
        {
            return value.Replace("'", "''").Replace("&", "&'||'");
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

        public override bool IsDeclareType(SchemaLoader.DataType dataType)
        {
            switch (dataType)
            {
                case SchemaLoader.DataType.XML:
                    return true;
                default:
                    return false;
            }
        }

        protected override string GetDataTypeMap(SchemaLoader.DataType dataType)
        {
            switch (dataType)
            {
                case SchemaLoader.DataType.XML:
                    return "CLOB";
                default:
                    return null;
            }
        }
    }
}
