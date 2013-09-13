using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Lists;
using HRCIS.SchemaLoader.Strategies;

namespace HRCIS.SchemaLoader
{
    public class SchemaLoader
    {
        private readonly ISchemaLoaderStrategy _schemaLoaderStrategy;

        public SchemaLoader()
            : this(new SqlSchemaLoader())
        {

        }
        public SchemaLoader(ISchemaLoaderStrategy schemaLoaderStrategy)
        {
            _schemaLoaderStrategy = schemaLoaderStrategy;
        }

        public TableList GetTableList()
        {
            return _schemaLoaderStrategy.GetTableList();
        }

        public HrcSchema GetSchema(HrcTable table)
        {
            return _schemaLoaderStrategy.GetSchema(table);
        }
    }
}
