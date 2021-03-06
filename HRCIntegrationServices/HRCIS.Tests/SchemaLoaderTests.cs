﻿using NUnit.Framework;
using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Enums;
using HRCIS.SchemaLoader.Lists;
using HRCIS.SchemaLoader.Strategies;

namespace HRCIS.Tests
{
    [TestFixture]
    public class SchemaLoaderTests
    {
        #region Init and tear down
        [TestFixtureSetUp]
        public void Init()
        {
            Tools.DropCreateTable();
        }

        //[TestFixtureTearDown]
        public void KillThemAll()
        {
            Tools.DropTable();
        }
        #endregion

        [Test, Ignore]
        public void GetTableList_Should_Be_Properly_Working()
        {
            var loader = new SchemaLoader.SchemaLoader();
            TableList tables = loader.GetTableList();
            HrcTable table = tables.GetTableName(Tools.HrcTestTableName);
            Assert.IsNotNull(table);
        }

        [Test, Ignore]
        public void GetSchema_Should_Be_Properly_Working()
        {
            var loader = new SchemaLoader.SchemaLoader();
            TableList tables = loader.GetTableList();
            HrcTable table = tables.GetTableName(Tools.HrcTestTableName);

            HrcSchema schema = loader.GetSchema(table);
            Assert.IsNotNull(schema);

            Assert.AreNotEqual(schema.Columns, 0);
        }

        //[Test]
        //public void GetTableList_Should_Be_Correct_SQLMOCK()
        //{
        //    var schemaLoaderStrategy = new Mock<ISchemaLoaderStrategy>();

        //    schemaLoaderStrategy.Setup(s => s.GetTableList())
        //        .Returns(() =>
        //            {
        //                return new TableList();
        //            });

        //    HRCIS.SchemaLoader.SchemaLoader loader = new HRCIS.SchemaLoader.SchemaLoader(schemaLoaderStrategy.Object);
        //    TableList tables = loader.GetTableList();
        //}

        [Test]
        public void SchemaColumns_Should_Be_Correct_ForSQL()
        {
            var sqlSchemaLoader = new SqlSchemaLoader();
            var loader = new SchemaLoader.SchemaLoader(sqlSchemaLoader);
            TableList tables = loader.GetTableList();
            HrcSchema testTable = loader.GetSchema(tables.GetTableName(Tools.HrcTestTableName));

            Assert.IsNotNull(testTable.Columns);

            HrcColumn id = testTable.Columns.GetColumnByColumnName("Id");
            Assert.AreEqual(id.ColumnDataType, DataType.INT);

            HrcColumn nVarCharColumn = testTable.Columns.GetColumnByColumnName("NVarCharColumn");
            Assert.AreEqual(nVarCharColumn.ColumnDataType, DataType.STRING);

            HrcColumn varCharColumn = testTable.Columns.GetColumnByColumnName("VarCharColumn");
            Assert.AreEqual(varCharColumn.ColumnDataType, DataType.STRING);

            HrcColumn bitColumn = testTable.Columns.GetColumnByColumnName("BitColumn");
            Assert.AreEqual(bitColumn.ColumnDataType, DataType.BOOLEAN);

            HrcColumn intColumn = testTable.Columns.GetColumnByColumnName("IntColumn");
            Assert.AreEqual(intColumn.ColumnDataType, DataType.INT);

            HrcColumn dateTimeColumn = testTable.Columns.GetColumnByColumnName("DateTimeColumn");
            Assert.AreEqual(dateTimeColumn.ColumnDataType, DataType.DATETIME);

            HrcColumn floatColumn = testTable.Columns.GetColumnByColumnName("FloatColumn");
            Assert.AreEqual(floatColumn.ColumnDataType, DataType.FLOAT);

            HrcColumn decimalColumn = testTable.Columns.GetColumnByColumnName("DecimalColumn");
            Assert.AreEqual(decimalColumn.ColumnDataType, DataType.DECIMAL);

            HrcColumn charColumn = testTable.Columns.GetColumnByColumnName("CharColumn");
            Assert.AreEqual(charColumn.ColumnDataType, DataType.Char);

            HrcColumn moneyColumn = testTable.Columns.GetColumnByColumnName("MoneyColumn");
            Assert.AreEqual(moneyColumn.ColumnDataType, DataType.Money);

            HrcColumn guidColumn = testTable.Columns.GetColumnByColumnName("GuidColumn");
            Assert.AreEqual(guidColumn.ColumnDataType, DataType.GUID);

            HrcColumn xmlColumn = testTable.Columns.GetColumnByColumnName("XmlColumn");
            Assert.AreEqual(xmlColumn.ColumnDataType, DataType.XML);

            HrcColumn dateColumn = testTable.Columns.GetColumnByColumnName("DateColumn");
            Assert.AreEqual(dateColumn.ColumnDataType, DataType.DATETIME);
        }
    }
}