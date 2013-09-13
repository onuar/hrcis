namespace HRCIS.SchemaLoader.Entities
{
    public class HrcTable
    {
        public string TableName { get; set; }

        public override string ToString()
        {
            return TableName;
        }
    }
}
