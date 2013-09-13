using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.DataLoader
{
    public class DataLoader
    {
        private SchemaLoader.SchemaList _schemas;
        private readonly DataLoaderStrategy _dataLoaderStrategy;

        public DataLoader(SchemaLoader.SchemaList schemas)
            : this(schemas,new HRCIS.DataLoader.SQLDataLoader())
        { }

        public DataLoader(
            SchemaLoader.SchemaList schemas
            , DataLoaderStrategy dataLoaderStrategy)
        {
            this._dataLoaderStrategy = dataLoaderStrategy;
            this._schemas = schemas;
        }

        public SchemaDataList GetSchemaDatas()
        {
            return _dataLoaderStrategy.GetSchemaDataList(_schemas);
        }
    }
}