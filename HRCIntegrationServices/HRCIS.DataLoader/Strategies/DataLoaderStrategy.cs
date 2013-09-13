using System.Data;
using HRCIS.DataLoader.Entities;
using HRCIS.DataLoader.Lists;
using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Lists;

namespace HRCIS.DataLoader.Strategies
{
    public abstract class DataLoaderStrategy
    {
        protected abstract DataTable GetSchemaDataInternal(HrcSchema schema);

        //template method
        public SchemaDataList GetSchemaDataList(SchemaList schemaList)
        {
            var list = new SchemaDataList();
            foreach (var schema in schemaList)
            {
                DataTable dt = this.GetSchemaDataInternal(schema);
                if (dt.Rows.Count == 0)
                    continue;
                var sd = new HrcSchemaData()
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
