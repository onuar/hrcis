using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Enums;
using HRCIS.SchemaLoader.Lists;

namespace HRCIS.SchemaLoader.Strategies
{
    public interface ISchemaLoaderStrategy
    {
        TableList GetTableList();
        HrcSchema GetSchema(HrcTable table);
        DataType GetHrcDataType(string columnDataType);
    }
}
