using HRCIS.SchemaLoader.Enums;

namespace HRCIS.SchemaLoader.TypeMapping
{
    public class HrcDbDataType
    {
        public HrcDbDataType(
            HrcDbType dbType
            , DataType dataType
            , string dbDataType
            , int size = -1
            )
        {
            DbType = dbType;
            this.HrcDataType = dataType;
            DbDataType = dbDataType;
            Size = size;
        }

        public HrcDbType DbType { get; set; }
        public DataType HrcDataType { get; set; }
        public string DbDataType { get; set; }
        public int Size { get; set; }
    }


    public enum HrcDbType
    {
        Sql = 1,
        Oracle = 2
    }
}
