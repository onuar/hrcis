using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HRCIS.SchemaLoader.TypeMapping;

namespace HRCIS.Tests
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void ShouldClobAndBlobForXMLType()
        {
            List<HrcDbDataType> oracleTypes = HrcMappingHelper.GetOracleType(SchemaLoader.DataType.XML);
            Assert.IsNotNull(oracleTypes.Where(t => t.DbDataType == "CLOB").Single());
            Assert.IsNotNull(oracleTypes.Where(t => t.DbDataType == "BLOB").Single());
        }
    }
}
