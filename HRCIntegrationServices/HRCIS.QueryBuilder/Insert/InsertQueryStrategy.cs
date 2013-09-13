using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRCIS.DataLoader;
using HRCIS.SchemaLoader;
using HRC.Foundation.ConvertionLibrary;
using System.Data;

namespace HRCIS.QueryBuilder
{
    public abstract class InsertQueryStrategy
    {
        private string GetDeclareName(HRCColumn column)
        {
            return string.Format("{0}Variable{1}"
                , GetDataTypeMap(column.ColumnDataType)
                , column.ColumnName);
        }

        public virtual string GenerateQuery(HRCSchemaData data, bool excludeIdentityColumn = false)
        {
            var strColumns = new StringBuilder();
            var strValues = new StringBuilder();
            var strDeclare = new StringBuilder();

            bool existDeclareType = false;

            foreach (var col in data.Schema.Columns)
            {
                if (excludeIdentityColumn
                    && col.IsIdentity)
                    continue;
                strColumns.Append(col.ColumnName + ",");

                if (IsDeclareType(col.ColumnDataType))
                {
                    strDeclare.Append(string.Format("DECLARE {0} {1};\n"
                        , GetDeclareName(col)
                        , GetDataTypeMap(col.ColumnDataType)));

                    existDeclareType = true;
                }
            }
            string columns = strColumns.ToString().TrimEnd(',');

            string query = string.Empty;
            string queries = string.Empty;

            StringBuilder strDeclareValues;

            foreach (DataRow row in data.Datas.Rows)
            {
                query = string.Empty;
                strValues = new StringBuilder();
                strDeclareValues = new StringBuilder();

                foreach (var col in data.Schema.Columns)
                {
                    if (excludeIdentityColumn
                        && col.IsIdentity)
                        continue;

                    object val = row[col.ColumnName];
                    bool hasApos = HasApostrophe(col.ColumnDataType);

                    if (val == null || val == DBNull.Value)
                    {
                        strValues.Append("NULL,");
                    }
                    else
                    {//value is not null
                        if (IsDeclareType(col.ColumnDataType))
                        {
                            strValues.Append(GetDeclareName(col) + ",");

                            strDeclareValues.Append(
                                GetDeclareName(col) + " := "
                                + (hasApos ? "'" + val + "'" : val.ToString())
                                + ";\n"
                                );
                        }
                        else
                        {
                            switch (col.ColumnDataType)
                            {
                                case SchemaLoader.DataType.BOOLEAN:
                                    val = ConvertToDbBooleanValue(ConvertionHelper.ConvertValue<bool>(val));
                                    break;
                                case SchemaLoader.DataType.DATETIME:
                                    val = ConvertToDbDateTimeValue(ConvertionHelper.ConvertValue<DateTime>(val));
                                    break;
                                case SchemaLoader.DataType.STRING:
                                    val = ConvertToDbStringValue(ConvertionHelper.ConvertValue<string>(val));
                                    break;
                                case SchemaLoader.DataType.FLOAT:
                                    val = ConvertToDbFloatValue(ConvertionHelper.ConvertValue<float>(val));
                                    break;
                                case SchemaLoader.DataType.DECIMAL:
                                    val = ConvertToDbDecimalValue(ConvertionHelper.ConvertValue<decimal>(val));
                                    break;
                                case SchemaLoader.DataType.Money:
                                    val = ConvertToDbMoneyValue(ConvertionHelper.ConvertValue<decimal>(val));
                                    break;
                                case DataType.GUID:
                                    val = ConvertToDbGuidValue(ConvertionHelper.ConvertValue<Guid>(val));
                                    break;
                                default:
                                    val = ConvertToDefaultValue(ConvertionHelper.ConvertValue<string>(val));
                                    break;
                            }

                            strValues.Append(
                                (hasApos ? "'" + val + "'" : val.ToString())
                                + ",");
                        }
                    }
                }

                if (existDeclareType)
                {
                    query = "\n" + strDeclareValues;
                }

                query += string.Format(
                    "\ninsert into {0} ({1}) values({2});"
                    , data.Schema.TableName
                    , columns
                   , strValues.ToString().TrimEnd(','));

                queries += " " + query;
            }

            if (existDeclareType)
            {
                queries = string.Format("{0} BEGIN \n" + queries + "\nEND;"
                    , strDeclare);
            }

            return queries;

        }

        public virtual bool IsDeclareType(DataType dataType)
        {
            return false;
        }

        protected abstract string GetDataTypeMap(DataType dataType);

        protected abstract bool HasApostrophe(DataType dataType);

        protected abstract string ConvertToDbBooleanValue(bool value);
        protected abstract string ConvertToDefaultValue(string value);
        protected abstract string ConvertToDbDateTimeValue(DateTime value);
        protected abstract string ConvertToDbStringValue(string value);
        protected abstract string ConvertToDbFloatValue(float value);
        protected abstract string ConvertToDbDecimalValue(decimal value);
        protected abstract string ConvertToDbMoneyValue(decimal value);
        protected abstract string ConvertToDbGuidValue(Guid value);
    }
}
