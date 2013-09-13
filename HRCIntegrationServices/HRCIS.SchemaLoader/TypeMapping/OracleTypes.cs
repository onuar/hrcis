using System.Collections.Generic;
using System.Linq;

namespace HRCIS.SchemaLoader.TypeMapping
{
    public class OracleTypes
    {
        static List<HrcDbDataType> _types = new List<HrcDbDataType>();

        static OracleTypes()
        {
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.XML, "CLOB"));
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.XML, "BLOB"));
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.INT, "NUMBER"));
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.STRING, "VARCHAR2"));
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.STRING, "NVARCHAR2"));
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.STRING, "NVARCHAR2", 2000));
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.GUID, "VARCHAR2", 40));
            _types.Add(new HrcDbDataType(HrcDbType.Oracle, DataType.GUID, "NVARCHAR2", 40));
        }

        public static List<HrcDbDataType> GetType(DataType dataType)
        {
            return _types.Where(t => t.HrcDataType == dataType).ToList();
        }

        #region Obsolete area
        //public const string Clob = "CLOB";
        //public const string Blob = "BLOB";
        //public const string Number = "Number";
        //public const string Int = "Int";
        //public const string Varchar = "Varchar";
        //public const string NVarchar2 = "NVarchar2";
        //public const string Date = "DATE";
        //public const string Float = "Number";
        //public const string Bit = "Number(1)";
        //public const string Decimal = "Number";
        //public const string Double = "Number";
        //public const string Guid = "Varchar2(40)";
        //public const string Char = "Char";
        //public const string Money = "Number";
        #endregion
    }
}