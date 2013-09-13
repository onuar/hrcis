using HRCIS.DataLoader.Entities;
using HRCIS.SchemaLoader.Entities;

namespace HRCIS.QueryBuilder.Insert
{
    public class InsertQueryBuilder
    {
        private readonly InsertQueryStrategy _insertQueryStrategy;
        private bool _excludeIdentityColumn = false;

        public InsertQueryBuilder()
            : this(new SqlQueryBuilder())
        {
        }

        public InsertQueryBuilder(InsertQueryStrategy insertQueryStrategy)
        {
            this._insertQueryStrategy = insertQueryStrategy;
        }

        public string GenerateQuery(HrcSchemaData data, bool excludeIdentityColumn = false)
        {
            return this._insertQueryStrategy.GenerateQuery(data, excludeIdentityColumn);
        }

        public string GenerateDeleteQuery(HrcSchema schema)
        {
            return string.Format("delete from {0};", schema.TableName);
        }
    }
}
