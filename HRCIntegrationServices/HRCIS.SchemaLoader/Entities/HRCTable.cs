using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader
{
    public class HRCTable
    {
        public string TableName { get; set; }

        public override string ToString()
        {
            return TableName;
        }
    }
}
