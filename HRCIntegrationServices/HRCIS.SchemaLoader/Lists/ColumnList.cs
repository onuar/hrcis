using System.Collections.Generic;
using System.Linq;
using HRCIS.SchemaLoader.Entities;

namespace HRCIS.SchemaLoader.Lists
{
    public class ColumnList : List<HrcColumn>
    {
        public HrcColumn GetColumnByColumnName(string columnName)
        {
            return this.FirstOrDefault(c => c.ColumnName == columnName);
        }

        public HrcColumn GetIdentityColumnIfExist()
        {
            return this.FirstOrDefault(c => c.IsIdentity);
        }
    }
}
