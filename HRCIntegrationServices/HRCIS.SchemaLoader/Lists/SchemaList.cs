using System.Collections.Generic;
using System.Linq;
using HRCIS.SchemaLoader.Entities;

namespace HRCIS.SchemaLoader.Lists
{
    public class SchemaList : List<HrcSchema>
    {
        public HrcSchema GetSchemaByTableName(string tableName)
        {
            return this.FirstOrDefault(s => s.TableName == tableName);
        }
    }
}
