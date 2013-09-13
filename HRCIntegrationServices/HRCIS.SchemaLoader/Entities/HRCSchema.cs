using HRCIS.SchemaLoader.Lists;

namespace HRCIS.SchemaLoader.Entities
{
    public class HrcSchema : HrcTable
    {
        public ColumnList Columns { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", this.TableName, (this.Columns == null ? 0 : this.Columns.Count));
        }
    }
}
