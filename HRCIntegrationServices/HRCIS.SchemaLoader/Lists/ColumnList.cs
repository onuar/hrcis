using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader
{
    public class ColumnList : List<HRCColumn>
    {
        public HRCColumn GetColumnByColumnName(string columnName)
        {
            foreach (var c in this)
            {
                if (c.ColumnName == columnName)
                    return c;
            }
            return null;
        }

        public HRCColumn GetIdentityColumnIfExist()
        {
            foreach (var c in this)
            {
                if (c.IsIdentity)
                    return c;
            }
            return null;
        }
    }
}
