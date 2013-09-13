using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRCIS.SchemaLoader;

namespace HRCIS.QueryBuilder
{
    public class InsertQueryBuilder
    {
        private readonly InsertQueryStrategy _insertQueryStrategy;
        private bool _excludeIdentityColumn = false;

        public InsertQueryBuilder()
            : this(new SQLQueryBuilder())
        {
        }

        public InsertQueryBuilder(InsertQueryStrategy insertQueryStrategy)
        {
            _insertQueryStrategy = insertQueryStrategy;
        }

        public string GenerateQuery(DataLoader.HRCSchemaData data, bool excludeIdentityColumn = false)
        {
            return _insertQueryStrategy.GenerateQuery(data, excludeIdentityColumn);
        }

        public string GenerateDeleteQuery(HRCSchema schema)
        {
            return string.Format("delete from {0};", schema.TableName);
        }
    }
}
