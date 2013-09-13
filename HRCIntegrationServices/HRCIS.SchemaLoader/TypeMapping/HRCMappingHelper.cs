using HRCIS.SchemaLoader.Enums;
using System.Collections.Generic;

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