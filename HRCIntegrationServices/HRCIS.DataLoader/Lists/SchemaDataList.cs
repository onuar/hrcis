using System.Collections.Generic;
using System.Linq;
using HRCIS.DataLoader.Entities;

namespace HRCIS.DataLoader.Lists
{
    public class SchemaDataList : List<HrcSchemaData>
    {
        public HrcSchemaData GetSchemaDataByTableName(string tableName)
        {
            return this.FirstOrDefault(sd => sd.Schema.TableName == tableName);
        }
    }
}