using System.Collections.Generic;
using System.Linq;

namespace HRCIS.DataLoader
{
    public class SchemaDataList : List<HRCSchemaData>
    {
        public HRCSchemaData GetSchemaDataByTableName(string tableName)
        {
            return this.FirstOrDefault(sd => sd.Schema.TableName == tableName);
        }
    }
}