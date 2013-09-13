using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader
{
    public interface ISchemaLoaderStrategy
    {
        TableList GetTableList();
        HRCSchema GetSchema(HRCTable table);
        DataType GetHRCDataType(string columnDataType);
    }
}
