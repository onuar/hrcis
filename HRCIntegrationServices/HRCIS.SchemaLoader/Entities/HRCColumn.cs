using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader
{
    public class HRCColumn
    {
        public string ColumnName { get; set; }
        public DataType ColumnDataType { get; set; }
        public int Size { get; set; }
        public bool IsIdentity { get; set; }
    }
}
