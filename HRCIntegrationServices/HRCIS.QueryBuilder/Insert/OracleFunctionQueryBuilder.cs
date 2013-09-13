using System;
using System.Text;
using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Enums;

namespace HRCIS.QueryBuilder.Insert
{
    public class OracleFunctionQueryBuilder
    {
        public string GenerateCreateSeqAndTrg(HrcSchema schema)
        {
            HrcColumn identityColumn = schema.Columns.GetIdentityColumnIfExist();
            if (identityColumn == null)
                throw new Exception("There is no identity column");
            if (identityColumn.ColumnDataType != DataType.INT)
                throw new Exception("Identity column type is not INT");

            var strQuery = new StringBuilder();

            strQuery.Append(string.Format(@"
             CREATE SEQUENCE {0}_SEQ
             START WITH 1
             INCREMENT BY   1
             NOCACHE
             NOCYCLE;

            create or replace trigger {0}_TRG
            before insert on {0}
            for each row
            begin
            select {0}_SEQ.nextval into :new.{1} from dual;
            end;", schema.TableName, identityColumn.ColumnName));

            return strQuery.ToString();
        }
    }
}
