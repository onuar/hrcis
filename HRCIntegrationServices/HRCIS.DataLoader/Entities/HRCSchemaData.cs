using System.Data;
using HRCIS.SchemaLoader.Entities;

namespace HRCIS.DataLoader.Entities
{
    public class HrcSchemaData
    {
        public HrcSchema Schema { get; set; }
        public DataTable Datas { get; set; }
    }
}
