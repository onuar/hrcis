using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRC.Foundation.ConvertionLibrary;
using HRC.Library.DBAccessLayer;
using System.Data.Common;
using HRC.Library.DBAccessLayer.Parameters;

namespace HRCIS.SchemaLoader
{
    public class SQLSchemaLoader : ISchemaLoaderStrategy
    {
        public DataType GetHRCDataType(string columnDataType)
        {
            columnDataType = columnDataType.ToLower();
            switch (columnDataType)
            {
                case "int":
                    return DataType.INT;
                case "varchar":
                    return DataType.STRING;
                case "nvarchar":
                    return DataType.STRING;
                case "bit":
                    return DataType.BOOLEAN;
                case "datetime":
                    return DataType.DATETIME;
                case "uniqueidentifier":
                    return DataType.GUID;
                case "float":
                    return DataType.FLOAT;
                case "double":
                    return DataType.DECIMAL;
                case "decimal":
                    return DataType.DECIMAL;
                case "char":
                    return DataType.Char;
                case "xml":
                    return DataType.XML;
                case "smalldatetime":
                    return DataType.DATETIME;
                case "money":
                    return DataType.Money;
                case "varbinary":
                    return DataType.Undefiened;
                case "image":
                    return DataType.Undefiened;
                case "date":
                    return DataType.DATETIME;
                default:
                    throw new NotImplementedException("Undefiened HRC Data Type: " + columnDataType);
            }
        }

        public TableList GetTableList()
        {
            TableList tableList = new TableList();

            using (DbManager db = new DbManager() { KeepConnection = true })
            {
                using (DbDataReader dr = db.ExecuteReader("select * from information_schema.tables Order By TABLE_NAME"))
                {
                    while (dr.Read())
                    {
                        HRCTable tbl = new HRCTable()
                        {
                            TableName = ConvertionHelper.ConvertValue<string>(dr["TABLE_NAME"])
                        };


                        tableList.Add(tbl);
                    }
                }
            }

            return tableList;
        }

        public HRCSchema GetSchema(HRCTable table)
        {
            ColumnList columns = new ColumnList();

            using (DbManager db = new DbManager())
            {
                db.Parameters.Clear();
                db.Parameters.Add(
                    new HRCParameter(
                        "tblName"
                        , table.TableName
                        , HRC.Library.DBAccessLayer.Parameters.HRCParameterType.STRING));

                using (DbDataReader drc =
                    db.ExecuteReader(@"
                        select *
                        ,COLUMNPROPERTY(OBJECT_ID(~tblName), COLUMN_NAME, 'IsIdentity') as IS_IDENTITY
                        from 
                        information_schema.columns 
                        where TABLE_NAME = ~tblName ORDER BY ORDINAL_POSITION"))
                {
                    while (drc.Read())
                    {
                        columns.Add(new HRCColumn()
                        {
                            ColumnDataType = ConvertionHelper.ConvertValue<DataType>(GetHRCDataType(drc["DATA_TYPE"].ToString()))
                            ,
                            ColumnName = ConvertionHelper.ConvertValue<string>(drc["COLUMN_NAME"])
                                //,
                                //Size = ConvertionHelper.ConvertValue<int>(drc["CHARACTER_MAXIMUM_LENGTH"] ?? 0) 
                            ,
                            IsIdentity = ConvertionHelper.ConvertValue<bool>(drc["IS_IDENTITY"])
                        });
                    }
                }

                HRCSchema schema = new HRCSchema();
                schema.TableName = table.TableName;
                schema.Columns = columns;

                return schema;
            }
        }
    }
}