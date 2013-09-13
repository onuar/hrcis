using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRCIS.SchemaLoader;
using System.Data;

namespace HRCIS.DataLoader
{
    public abstract class DataLoaderStrategy
    {
        protected abstract DataTable GetSchemaDataInternal(HRCSchema schema);

        //template method
        public SchemaDataList GetSchemaDataList(SchemaList schemaList)
        {
            var list = new SchemaDataList();
            foreach (var schema in schemaList)
            {
                DataTable dt = GetSchemaDataInternal(schema);
                if (dt.Rows.Count == 0)
                    continue;
                var sd = new HRCSchemaData()
                {
                    Schema = schema
                    ,
                    Datas = dt
                };
                list.Add(sd);
            }
            return list;
        }
    }
}
