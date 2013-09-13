using NUnit.Framework;
using HRCIS.DataLoader.Lists;
using HRCIS.QueryBuilder.Insert;
using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Lists;
using HRC.Library.DBAccessLayer;

namespace HRCIS.Tests
{
    [TestFixture]
    public class InsertQueryBuilderTests
    {
        #region Init and tear down
        //[TestFixtureSetUp]
        //public void Init()
        //{
        //    Tools.DropCreateTable();
        //}

        //[TestFixtureTearDown]
        //public void KillThemAll()
        //{
        //    Tools.DropTable();
        //}
        #endregion

        [Test]
        public void Should_Query_Equal_SchemaColumn()
        {
            var schemaList = new SchemaList();
            var sLoader = new SchemaLoader.SchemaLoader();
            schemaList.Add(sLoader.GetSchema(new HrcTable() { TableName = Tools.HrcTestTableName }));

            var dLoader = new DataLoader.DataLoader(schemaList);
            SchemaDataList datas = dLoader.GetSchemaDatas();

            var builder = new InsertQueryBuilder();
            string query = builder.GenerateQuery(datas[0]);
            Assert.IsNotNull(query);
        }

        [Test]
        public void Should_Generated_Query_Executable()
        {
            var schemaList = new SchemaList();
            var sLoader = new SchemaLoader.SchemaLoader();
            schemaList.Add(sLoader.GetSchema(new HrcTable() { TableName = Tools.HrcTestTableName }));

            var dLoader = new DataLoader.DataLoader(schemaList);
            SchemaDataList datas = dLoader.GetSchemaDatas();

            var builder = new InsertQueryBuilder();
            string query = builder.GenerateQuery(datas[0], true);

            using (var db = new DbManager())
            {
                db.ExecuteNonQuery(query);
            }
        }
    }
}
