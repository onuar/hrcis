using System;
using System.Text;
using HRC.Foundation.ConvertionLibrary;
using System.Data;
using HRCIS.DataLoader.Entities;
using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Enums;

namespace HRCIS.QueryBuilder.Insert
{
    public abstract class InsertQueryStrategy
    {
        private string GetDeclareName(HrcColumn column)
        {
            return string.Format("{0}Variable{1}"
                , this.GetDataTypeMap(column.ColumnDataType)
                , column.ColumnName);
        }

        public virtual string GenerateQuery(HrcSchemaData data, bool excludeIdentityColumn = false)
        {
            StringBuilder values;
            var columnNames = new StringBuilder();
            var declares = new StringBuilder();

            bool existDeclareType = false;

            foreach (var col in data.Schema.Columns)
            {
                if (excludeIdentityColumn
                    && col.IsIdentity)
                    continue;
                columnNames.Append(col.ColumnName + ",");

                if (this.IsDeclareType(col.ColumnDataType))
                {
                    declares.Append(string.Format("DECLARE {0} {1};\n"
                        , this.GetDeclareName(col)
                        , this.GetDataTypeMap(col.ColumnDataType)));

                    existDeclareType = true;
                }
            }
            string columns = columnNames.ToString().TrimEnd(',');

            string query = string.Empty;
            string queries = string.Empty;

            StringBuilder strDeclareValues;

            foreach (DataRow row in data.Datas.Rows)
            {
                query = string.Empty;
                values = new StringBuilder();
                strDeclareValues = new StringBuilder();

                foreach (var col in data.Schema.Columns)
                {
                    if (excludeIdentityColumn
                        && col.IsIdentity)
                        continue;

                    object val = row[col.ColumnName];
                    bool hasApos = this.HasApostrophe(col.ColumnDataType);

                    if (val == null || val == DBNull.Value)
                    {
                        values.Append("NULL,");
                    }
                    else
                    {//value is not null
                        if (this.IsDeclareType(col.ColumnDataType))
                        {
                            values.Append(this.GetDeclareName(col) + ",");

                            strDeclareValues.Append(
                                this.GetDeclareName(col) + " := "
                                + (hasApos ? "'" + val + "'" : val.ToString())
                                + ";\n"
                                );
                        }
                        else
                        {
                            switch (col.ColumnDataType)
                            {
                                case DataType.BOOLEAN:
                                    val = this.ConvertToDbBooleanValue(ConvertionHelper.ConvertValue<bool>(val));
                                    break;
                                case DataType.DATETIME:
                                    val = this.ConvertToDbDateTimeValue(ConvertionHelper.ConvertValue<DateTime>(val));
                                    break;
                                case DataType.STRING:
                                    val = this.ConvertToDbStringValue(ConvertionHelper.ConvertValue<string>(val));
                                    break;
                                case DataType.FLOAT:
                                    val = this.ConvertToDbFloatValue(ConvertionHelper.ConvertValue<float>(val));
                                    break;
                                case DataType.DECIMAL:
                                    val = this.ConvertToDbDecimalValue(ConvertionHelper.ConvertValue<decimal>(val));
                                    break;
                                case DataType.Money:
                                    val = this.ConvertToDbMoneyValue(ConvertionHelper.ConvertValue<decimal>(val));
                                    break;
                                case DataType.GUID:
                                    val = this.ConvertToDbGuidValue(ConvertionHelper.ConvertValue<Guid>(val));
                                    break;
                                default:
                                    val = this.ConvertToDefaultValue(ConvertionHelper.ConvertValue<string>(val));
                                    break;
                            }

                            values.Append(
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
                   , values.ToString().TrimEnd(','));

                queries += " " + query;
            }

            if (existDeclareType)
            {
                queries = string.Format("{0} BEGIN \n" + queries + "\nEND;"
                    , declares);
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
