using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader
{
    public class TableList : List<HRCTable>
    {
        public HRCTable GetTableName(string tableName)
        {
            foreach (var t in this)
            {
                if (t.TableName == tableName)
                    return t;
            }
            return null;
        }
    }
}
