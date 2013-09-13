using NUnit.Framework;
using HRCIS.DataLoader;
using HRCIS.SchemaLoader;
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
            schemaList.Add(sLoader.GetSchema(new HRCTable() { TableName = Tools.HrcTestTableName }));

            var dLoader = new DataLoader.DataLoader(schemaList);
            SchemaDataList datas = dLoader.GetSchemaDatas();

            var builder = new QueryBuilder.InsertQueryBuilder();
            string query = builder.GenerateQuery(datas[0]);
            Assert.IsNotNull(query);
        }

        [Test]
        public void Should_Generated_Query_Executable()
        {
            var schemaList = new SchemaList();
            var sLoader = new SchemaLoader.SchemaLoader();
            schemaList.Add(sLoader.GetSchema(new HRCTable() { TableName = Tools.HrcTestTableName }));

            var dLoader = new DataLoader.DataLoader(schemaList);
            SchemaDataList datas = dLoader.GetSchemaDatas();

            var builder = new QueryBuilder.InsertQueryBuilder();
            string query = builder.GenerateQuery(datas[0], true);

            using (var db = new DbManager())
            {
                db.ExecuteNonQuery(query);
            }
        }
    }
}
