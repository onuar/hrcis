using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader
{
    public class HRCSchema : HRCTable
    {
        public ColumnList Columns { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", TableName, (Columns == null ? 0 : Columns.Count));
        }
    }
}
