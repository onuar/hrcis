using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRC.Library.DBAccessLayer;
using HRC.Foundation.ConfigLibrary;

namespace HRCIS.DataLoader
{
    public class SQLDataLoader : DataLoaderStrategy
    {
        protected override DataTable GetSchemaDataInternal(SchemaLoader.HRCSchema schema)
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
