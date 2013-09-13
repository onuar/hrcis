using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader.TypeMapping
{
    public class SqlTypes
    {
        static List<HrcDbDataType> _types = new List<HrcDbDataType>();

        static SqlTypes()
        {//todo@onuar: 05.09.2012 devam edecek...

        }

        public static List<HrcDbDataType> GetType(DataType dataType)
        {
            return _types.Where(t => t.HrcDataType == dataType).ToList();
        }
    }
}
