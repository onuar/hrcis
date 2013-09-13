using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader
{
    public class SchemaList : List<HRCSchema>
    {
        public HRCSchema GetSchemaByTableName(string tableName)
        {
            foreach (var s in this)
            {
                if (s.TableName == tableName)
                    return s;
            }
            return null;
        }
    }
}
