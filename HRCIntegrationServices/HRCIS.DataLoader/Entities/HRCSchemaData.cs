using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRCIS.SchemaLoader;
using System.Data;

namespace HRCIS.DataLoader
{
    public class HRCSchemaData
    {
        public HRCSchema Schema { get; set; }
        public DataTable Datas { get; set; }
    }
}
