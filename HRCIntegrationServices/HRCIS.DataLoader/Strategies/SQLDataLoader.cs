using System.Data;
using HRC.Library.DBAccessLayer;
using HRCIS.SchemaLoader.Entities;

namespace HRCIS.DataLoader.Strategies
{
    public class SqlDataLoader : DataLoaderStrategy
    {
        protected override DataTable GetSchemaDataInternal(HrcSchema schema)
        {
            var dt = new DataTable();
            using (var db = new DbManager())
            {
                dt = db.ExecuteDataTable(string.Format("select * from {0}", schema.TableName));
            }
            return dt;
        }
    }
}
