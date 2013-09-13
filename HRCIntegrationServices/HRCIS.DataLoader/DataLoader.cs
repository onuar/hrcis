using HRCIS.DataLoader.Lists;
using HRCIS.DataLoader.Strategies;
using HRCIS.SchemaLoader.Lists;

namespace HRCIS.DataLoader
{
    public class DataLoader
    {
        private readonly SchemaList _schemas;
        private readonly DataLoaderStrategy _dataLoaderStrategy;

        public DataLoader(SchemaList schemas)
            : this(schemas,new SqlDataLoader())
        { }

        public DataLoader(
            SchemaList schemas
            , DataLoaderStrategy dataLoaderStrategy)
        {
            _dataLoaderStrategy = dataLoaderStrategy;
            _schemas = schemas;
        }

        public SchemaDataList GetSchemaDatas()
        {
            return _dataLoaderStrategy.GetSchemaDataList(_schemas);
        }
    }
}