using HRCIS.SchemaLoader.Enums;

namespace HRCIS.SchemaLoader.Entities
{
    public class HrcColumn
    {
        public string ColumnName { get; set; }
        public DataType ColumnDataType { get; set; }
        public int Size { get; set; }
        public bool IsIdentity { get; set; }
    }
}
