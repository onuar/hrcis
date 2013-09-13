namespace HRCIS.SchemaLoader
{
    public class SchemaLoader
    {
        private readonly ISchemaLoaderStrategy _schemaLoaderStrategy;

        public SchemaLoader()
            : this(new SQLSchemaLoader())
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

        public HRCSchema GetSchema(HRCTable table)
        {
            return _schemaLoaderStrategy.GetSchema(table);
        }
    }
}
