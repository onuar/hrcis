using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRCIS.SchemaLoader.TypeMapping
{
    public class HrcMappingHelper
    {
        public static List<HrcDbDataType> GetOracleType(DataType dataType)
        {
            return OracleTypes.GetType(dataType);
        }

        public static List<HrcDbDataType> GetSqlType(DataType dataType)
        {
            return SqlTypes.GetType(dataType);
        }
    }
}