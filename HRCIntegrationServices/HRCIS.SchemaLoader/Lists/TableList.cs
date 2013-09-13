using System.Collections.Generic;
using System.Linq;
using HRCIS.SchemaLoader.Entities;

namespace HRCIS.SchemaLoader.Lists
{
    public class TableList : List<HrcTable>
    {
        public HrcTable GetTableName(string tableName)
        {
            return this.FirstOrDefault(t => t.TableName == tableName);
        }
    }
}
