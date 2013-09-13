using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRC.Foundation.ConvertionLibrary;

namespace HRCIS.QueryBuilder
{
    public class SQLQueryBuilder : InsertQueryStrategy
    {
        protected override bool HasApostrophe(SchemaLoader.DataType dataType)
        {
            switch (dataType)
            {
                case HRCIS.SchemaLoader.DataType.Undefiened:
                    return true;
                case HRCIS.SchemaLoader.DataType.STRING:
                    return true;
                case HRCIS.SchemaLoader.DataType.DATETIME:
                    return true;
                case HRCIS.SchemaLoader.DataType.GUID:
                    return true;
                case HRCIS.SchemaLoader.DataType.Char:
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
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }
        protected override string ConvertToDbStringValue(string value)
        {
            return value.ToString().Replace("'", "''");
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

        protected override string GetDataTypeMap(SchemaLoader.DataType dataType)
        {
            return string.Empty;
        }
    }
}
